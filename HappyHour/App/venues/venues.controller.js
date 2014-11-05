(function() {
    'use strict';

    angular
        .module('hppyhr')
        .controller('venuesController', venuesController);

    venuesController.$inject = ['$http', '$window', 'GoogleMapApi'.ns(), 'foursquare'];

    function venuesController($http, $window, GoogleMapApi, foursquare) {
        var vm = this;
        vm.venues = null;

        activate();

        function activate() {
            GoogleMapApi.then(function(maps) {

                $http.get('/venues').then(function(response) {
                    vm.venues = response.data;
                    angular.forEach(vm.venues, function(venue) {
                        venue.center = { latitude: venue.latitude, longitude: venue.longitude };
                    });
                }, function(data) {
                    console.log(data);
                });
            });

            $window.navigator.geolocation.getCurrentPosition(function(position) {
                foursquare.venues.explore(position.coords).success(function(response) {
                    console.log(response);
                });
            });
            
        }
    }

})();