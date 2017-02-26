namespace CastleClashdb.Services {
    export class CategoryService {
        private catResource: ng.resource.IResourceClass<Models.Category>;

        static $inject = ['$resource', '$http'];
        constructor(
            $resource: ng.resource.IResourceService,
            private $http: ng.IHttpService
        ) {
            this.catResource = $resource<Models.Category>('api/category');
        }

        //get all categories
        public getAllCats(): Models.Category[] {

            return this.catResource.query();

        }
        //get
        public getCategory(id: number): Models.Category {
            return this.catResource.get({ id: id });
        }

        public saveCat(category: Models.Category): ng.IPromise<Models.Category> {
            return this.$http.post<Models.Category>('api/category', category)
                .then((response) => {
                    return response.data;
                });


        }

        //delete
        public deleteCategory(id: number) {
            this.catResource.delete({ id: id });
        }
    }
}
