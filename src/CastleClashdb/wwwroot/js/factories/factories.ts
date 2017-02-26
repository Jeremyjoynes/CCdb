namespace CastleClashdb.Factories {
    let module: ng.IModule = angular.module('CastleClashdb.Factories', []);

    module.factory('AuthenticationInterceptor', Factories.AuthenticationInterceptor);
}