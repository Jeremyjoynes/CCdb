namespace CastleClashdb.Views.Home {
    export class HomeController {
        public heroes: Models.Hero[];
        public categories: Models.Category[];

        public newHero: Models.Hero = new Models.Hero();

        static $inject = [
            'HeroService',
            'CategoryService',
            'UserService',
            '$uibModal'


        ];
        constructor(
            private HeroService: Services.HeroService,
            private CategoryService: Services.CategoryService,
            private UserService: Services.UserService,
            private $uibModal: ng.ui.bootstrap.IModalService
        ) {
            this.heroes = this.HeroService.getAllHeroes();
            this.categories = this.CategoryService.getAllCats();
        }
        //var x = (<HTMLInputElement>document.getElementById('hero')).value;
        //code goes here;
        public saveHero(): void {
            this.HeroService.saveHero(this.newHero)
                .then((hero) => {
                    this.heroes.push(hero);
                });
            this.newHero = new Models.Hero();
        }
        public editHero(editHero: Models.Hero): void {
            let self = this;
            let settings = <ng.ui.bootstrap.IModalSettings>{
                keyboard: false,
                templateUrl: 'js/views/home/edit.modal.view.html',
                controller: 'EditHeroController',
                controllerAs: 'vm',
                size: 'lg',
                resolve: {
                    hero: (): Models.Hero => {
                        return angular.copy(editHero);
                    }
                }
            };

            let modal = this.$uibModal.open(settings);
            modal.result.then(function (updateHero: Models.Hero) {
                self.HeroService.updateHero(updateHero);
            }, function () {
                console.log('Modal dismissed at: ' + new Date());
            });
        }

        public deleteHero(id: number): void {
            this.HeroService.deleteHero(id);

            var index = _.findIndex(this.heroes, (item) => {
                return item.id === id;
            });
            this.heroes.splice(index, 1);
        }
        public canEdit(): boolean {
            return this.UserService.isLoggedIn;
        }
        public canDelete(): boolean {

            return this.UserService.isLoggedIn
                && this.UserService.user.isAdmin;

        //    if (this.UserService.isLoggedIn) {
        //        if (this.UserService.user.isAdmin) {
        //            return true;
        //        }
        //    }

        //    return false;
        }
    }

}