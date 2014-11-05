(function() {
    angular
        .module('foursquare', []);

    angular
        .module('foursquare')
        .provider('foursquare', foursquareProvider);

    function foursquareProvider() {
        var clientId;
        var clientSecret;

        var provider = {
            setClientId: setClientId,
            setClientSecret: setClientSecret,
            $get: ['$http', get]
        };

        return provider;

        function setClientId(id) {
            clientId = id;
        }

        function setClientSecret(secret) {
            clientSecret = secret;
        }

        function get($http) {
            var credentials = {
                clientId: clientId,
                clientSecret: clientSecret
            }

            return {
                venues: {
                    explore: function(coords) {
                        var url = 'https://api.foursquare.com/v2/venues/explore';
                        return $http.get(url, {
                            params: {
                                client_id: credentials.clientId,
                                client_secret: credentials.clientSecret,
                                ll: coords.latitude.toString() + ',' + coords.longitude.toString(),
                                v: '20141031'
                            }
                        });
                    }
                }
            }
        }
    }

})();