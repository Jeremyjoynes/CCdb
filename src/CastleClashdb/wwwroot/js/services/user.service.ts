namespace CastleClashdb.Services {
    export class UserService {
        private isUserLoggedIn: boolean = false;
        private authUser: Models.UserModel = new Models.UserModel();

        public get isLoggedIn(): boolean {
            return this.isUserLoggedIn;
        }

        public get user(): Models.UserModel {
            return this.authUser;
        }


        static $inject = [
            '$http',
            '$window'
        ];

        constructor(
            private $http: ng.IHttpService,
            private $window: ng.IWindowService
        ) {
            this.getSessionData();
        }


        private clearSession(): void {
            this.$window.sessionStorage.clear();
            this.authUser = Models.UserModel.GetAnonymousUser();
            this.isUserLoggedIn = false;
        }
        private getSessionData() {
            let user = this.$window.sessionStorage.getItem('user');

            if (user) {
                this.authUser = <Models.UserModel>JSON.parse(user);
                this.isUserLoggedIn = true;
                return;
            }
            this.authUser = Models.UserModel.GetAnonymousUser();
            this.isUserLoggedIn = false;
            return;
        }

        private updateSession(user: Models.UserModel): boolean {
            var encodedUser = JSON.stringify(user);

            if (encodedUser) {
                this.$window.sessionStorage.setItem('user', encodedUser);
                this.isUserLoggedIn = true;
                return true;
            }
            this.clearSession();
            return false;

        }
        public logOut(): void {
            this.$http.post<Models.UserModel>('api/account/logOff', <ng.IRequestShortcutConfig>{
                cache: false
            })
                .then((response) => {
                    console.info('User login was logged out.');
                    this.authUser = null;
                    this.isUserLoggedIn = false;
                    
                })
                .catch(() => {
                    // post is not working so forcing user logout.
                    //this.clearSession();
                    
                    console.info('User was not logged out.')
                });
        }

        public loginUser(user: Models.LoginViewModel): ng.IPromise<boolean> {
            return this.$http.post<Models.UserModel>('api/account/login', user, <ng.IRequestShortcutConfig>{
                cache: false
            })
                .then((response) => {
                    console.info('User login was successful.');
                    this.authUser = response.data;
                    return this.updateSession(response.data);
                })
                .catch(() => {
                    console.info('User was not logged in.');
                    return this.updateSession(null);
                });

        }
    }
}