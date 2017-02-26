namespace CastleClashdb.Views.Home {
    export class EditHeroController {
        public category: Models.Category[];

        static $inject = [
            'CategoryService',
            '$uibModalInstance',
            'hero'
        ];

        constructor(
            CategoryService: Services.CategoryService,
            private $uibModualInstance: ng.ui.bootstrap.IModalServiceInstance,
            public hero: Models.Hero
        ) {
            this.category = CategoryService.getAllCats();
            this.hero = hero;
        }
        public save(): void {
            this.$uibModualInstance.close(this.hero);
        }
        public cancel(): void {
            this.$uibModualInstance.dismiss('cancel');
        }
    }
}