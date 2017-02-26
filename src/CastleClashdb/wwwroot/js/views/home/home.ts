namespace CastleClashdb.Views.Home {
    let module: ng.IModule = angular.module('View.Home', []);

   
    module.controller('HomeController', Home.HomeController);
    module.controller('EditHeroController', Home.EditHeroController);
    module.config(Home.Configuration);
}