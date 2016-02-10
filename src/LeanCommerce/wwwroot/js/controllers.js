angular.module('leancommerce.controllers', [])

.controller('CategorySetupGridController', function ($scope) {
    $('.mvc-grid').mvcgrid({
        rowClicked: function (grid, row, data) {
            console.log('data: ' + data);
            console.log('grid: ' + grid);
        }
    })
})

.controller('LayoutController', function ($scope, $location, Settings) {

});