namespace CastleClashdb.Views.ForgotPassword {
    Configuration.$inject = ['$stateProvider'];

    export function Configuration(
        $stateProvier: ng.ui.IStateProvider
    ) {
        $stateProvier.state('ForgotPassword', <ng.ui.IState>{
            url: '/forgotpassword',
            templateUrl: 'js/views/forgotpassword/forgotpassword.view.html',
            controller: 'AboutController',
            controllerAs: 'vm'
        });
    }
}