namespace CastleClashdb.Services {

    export class ResourceService {

        protected updateResourceAction: ng.resource.IActionHash = {
            'update': { method: 'PUT' }
        };
    }
    export class HeroService extends ResourceService {
        private heroResource: IUpdatableResourceClass<Models.Hero>;

        static $inject = [
            '$resource',
            '$http'
        ];

        constructor(
            $resource: ng.resource.IResourceService,
            private $http: ng.IHttpService
        ) {
            super();
            this.heroResource = $resource<Models.Hero, IHeroResourceClass>('api/hero/:id', null, this.updateResourceAction);
        }
        //get all heroes
        public getAllHeroes(): Models.Hero[] {

            return this.heroResource.query();
        }

        //get
        public getHero(id: number): Models.Hero {
            return this.heroResource.get({ id: id });
        }

        // save a new hero
        public saveHero(hero: Models.Hero): ng.IPromise<Models.Hero> {
            return this.$http.post<Models.Hero>('api/hero/', hero)
                .then((response) => {
                    console.log(response.data);
                    return response.data;
                });
        }

        //update Hero
        public updateHero(hero: Models.Hero): void {
            this.heroResource.update({ id: hero.id }, hero);
        }

        //delete Hero
        public deleteHero(id: number) {
            this.heroResource.delete({ id: id });
        }


    }
    interface IHeroResourceClass extends IUpdatableResourceClass<Models.Hero> {

    }

    interface IUpdatableResourceClass<T> extends ng.resource.IResourceClass<T> {

        update(): T;
        update(params: Object): T;
        update(success: Function, error?: Function): T;
        update(params: Object, sucess: Function, error?: Function): T;
        update(params: Object, data: Object, success?: Function, error?: Function): T;
    }
}