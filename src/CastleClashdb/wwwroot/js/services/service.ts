namespace CastleClashdb.Services {
    let module: ng.IModule = angular.module('CastleClashdb.Services', []);

    module.service('RegistrationService', Services.RegistrationService);
    module.service('UserService', Services.UserService);
    module.service('HeroService', Services.HeroService);
    module.service('CategoryService', Services.CategoryService);
}