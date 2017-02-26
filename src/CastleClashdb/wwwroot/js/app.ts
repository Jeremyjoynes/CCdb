namespace CastleClashdb {
    let module: ng.IModule = angular.module('CastleClashdb', [
        'ui.router',
        'ngResource',
        'ui.bootstrap',

        'CastleClashdb.Factories',
        'CastleClashdb.Services',
        'CastleClashdb.Views'

    ]);
    module.controller('ApplicationController', CastleClashdb.ApplicationController);
    module.config(CastleClashdb.Configuration);
    module.run(CastleClashdb.Run);
}