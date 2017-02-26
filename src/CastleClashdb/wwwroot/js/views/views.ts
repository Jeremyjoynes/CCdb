namespace CastleClashdb.Views {
    let module: ng.IModule = angular.module('CastleClashdb.Views', [
        //required subModules
        'View.Home',
        'View.Contact',
        'View.About',
        'View.Register',
        'View.Login',
        'View.ForgotPassword'

    ]);
}