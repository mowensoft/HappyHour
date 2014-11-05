(function() {
    'use strict';

    angular
        .module('hppyhr')
        .config(configure);

    configure.$inject = ['$stateProvider', 'foursquareProvider'];

    function configure($stateProvider, foursquareProvider) {
        
        $stateProvider
            .state('venues', {
                url: '/venues',
                templateUrl: 'app/venues/venues.html',
                controller: 'venuesController as vm'
            });

        
    }

    angular
        .module('hppyhr')
        .config([
            'GoogleMapApiProvider'.ns(), function(GoogleMapApi) {
                GoogleMapApi.configure({
                    key: '',
                    v: '3.17',
                    libraries: 'weather,geometry,visualization'
                });
            }
        ]);
})();