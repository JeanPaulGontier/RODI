angular.module("App", [])
    .directive('textTransforms', ['$parse', function ($parse) {
        return {
            restrict: 'A',
            require: '^ngModel',
            scope: {
                value: '=ngModel',
                caseTitle: '@textTransforms'
            },
            link: function postLink(scope, element, attrs) {
                scope.$watch('value', function (modelValue, viewValue) {
                    if (modelValue) {
                        var newValue;
                        switch (scope.caseTitle) {
                            case 'uppercase':
                                newValue = modelValue.toUpperCase();
                                break;
                            case 'lowercase':
                                newValue = modelValue.toLowerCase();
                                break;
                            case 'capitalize':
                                newValue = modelValue.charAt(0).toUpperCase() + modelValue.slice(1);
                                break;
                            default:
                                newValue = modelValue;
                        }
                        $parse('value').assign(scope, newValue);
                    }
                });
            }
        };
    }])

    .controller("AppController", function ($scope, $http, $location) {

        $scope.init = function (CID) {
            $scope.CID = CID;
            $scope.serviceurl = $location.absUrl() + "?CID=" + $scope.CID;
            $scope.getData("getAgenda", {},
                (reponse) =>
                {
                    $scope.agenda = reponse.data;
                },
                (reponse) => {
                    alert(reponse.data);
                }
            );
        };
        $scope.getData = function (action, parms, callBackOk, callBackError) {

            var pStr = "&action=" + encodeURIComponent(action);
            for (p in parms) {
                pStr += "&" + p + "=" + encodeURIComponent(parms[p]);
            }
            $http.get($scope.serviceurl + pStr)
                .then(callBackOk, callBackError);
        };
        $scope.putData = function (action, obj, callBackOk, callBackError) {
            if (callBackError === undefined)
                callBackError = function (reponse) {
                    $scope.errorMessage = reponse.data.Value;
                    alert($scope.errorMessage);

                };
            if (callBackOk === undefined)
                callBackOk = function (reponse) {
                    //$mdToast.show(
                    //    $mdToast.simple()
                    //        .textContent('Ok')
                    //        .position('top right')
                    //        .hideDelay(3000))
                };
            $http({
                method: "post",
                url: $scope.serviceurl,
                data: {
                    Key: action,
                    Value: obj
                }
            }).then(callBackOk, callBackError);
        };
     

    });