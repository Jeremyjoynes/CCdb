namespace CastleClashdb.Models {
    export class UserModel {
        public userName: string = '';
        public isAdmin: boolean = false;
       // public anonymousUser: boolean = true;


        public static GetAnonymousUser(): Models.UserModel {
            let user = new Models.UserModel();
            user.userName = 'Anonymous';
            return user;
        }
    }
}