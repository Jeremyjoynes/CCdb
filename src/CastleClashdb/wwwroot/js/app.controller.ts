namespace CastleClashdb {

    export class ApplicationController
    {
        public get isUserLoggedIn() {
            return this.UserService.isLoggedIn;
        }
        public get user(): Models.UserModel {
            return this.UserService.user;
        }
        public logOut(): void {
            this.UserService.logOut();
            this.$state.go('Home');
        }

        static $inject = [
            'UserService',
            '$state'
        ];

        constructor(
            private UserService: Services.UserService,
            private $state: ng.ui.IStateService
        ) { }
    
    }
}