﻿namespace CastleClashdb.Views.Contact {
    let module: ng.IModule = angular.module('View.Contact', []);

    module.config(Contact.Configuration);
    module.controller('ContactController', Contact.ContractController);
}