(function () {
    var designerModule = angular.module('designer');

    angular.module('designer').requires.push('sfSelectors');

    designerModule.controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {
        $scope.feedback.showLoadingIndicator = true;
        $scope.itemSelector = { selectedItemsIds: [] };

        propertyService.get().then(function (data) {
            if (data) {
                $scope.properties = propertyService.toAssociativeArray(data.Items);

                var selectedItemsIds = $.parseJSON($scope.properties.SerializedSelectedItemsIds.PropertyValue || null);
                if (selectedItemsIds) {
                    $scope.itemSelector.selectedItemsIds = selectedItemsIds;
                }
            }
        },

            function (data) {
                $scope.feedback.showError = true;
                if (data) {
                    $scope.feedback.errorMessage = data.Detail;
                }
            })
            .finally(function () {
                $scope.feedback.showLoadingIndicator = false;
            });


        $scope.$watch('itemSelector.selectedItemsIds', function (newValue) {
            if (newValue.length > 0) {
                $scope.properties.SerializedSelectedItemsIds.PropertyValue = JSON.stringify(newValue);
            }
        });

    }]);
})();
