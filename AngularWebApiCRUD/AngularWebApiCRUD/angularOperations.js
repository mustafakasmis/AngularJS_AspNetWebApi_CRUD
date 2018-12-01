var app = angular.module("myApp", []);

var user;
var deleteUser;

app.controller("myCtr", function ($scope,$http) {

      // SELECT USERS
      $http({
           method: "GET",
           url: "http://localhost:58231/api/users",
           }).then(function mySuccess(response) {
           $scope.users = response.data;
          }, function myError(response) {
              alert(response.statusText);
      });


    // THE EDIT MODAL FILL USER DATA
    $scope.editUserData = function (x) {

            var editModal = document.getElementById("edituser");
            editModal.style.display = "block";
            user = x;
            $scope.editingDataName = x.name;
            $scope.editingDataSurname = x.surname;
  
    };


    // EDITING USER DATA AND SAVE
    $scope.saveEditData = function (x, y) {

            $http({
                method: "PUT",
                url: "http://localhost:58231/api/users/" + user.id,
                data: { id:user.id, name: x, surname: y }
            }).then(function mySuccess(response) {
                $scope.users = response.data;
                }, function myError(response) {
                    alert(response.statusText);
            });
            document.getElementById("edituser").style.display = "none";

    };


    // ADD NEW USER
    $scope.addNewUser = function (x,y) {

            $http({
                method: "POST",
                url: "http://localhost:58231/api/users",
                data: { name: x, surname: y }
            }).then(function mySuccess(response) {
                if (response !== null)
                    $scope.users = response.data;
                $scope.newUserName = "";
                $scope.newUserSurname = "";
                }, function myError(response) {
                    alert(response.statusText);
            });

            document.getElementById("adduser").style.display = "none";

    };


    // THE DELETE MODAL FILL USER DATA
    $scope.deleteUserData = function (x) {      
            var deleteModal = document.getElementById("deleteuser");
            deleteModal.style.display = "block";
            deleteUser = x;
            $scope.deleteUserName = x.name;
            $scope.deleteUserSurname = x.surname;
    };


    // DELETE USER
    $scope.deleteUser = function () {

            $http({
                method: "DELETE",
                url: "http://localhost:58231/api/users/" + deleteUser.id
            }).then(function mySuccess(response) {
                $scope.users = response.data;
                }, function myError(response) {
                    alert(response.statusText);
                });
        document.getElementById("deleteuser").style.display = "none";

    };


    // CANCEL DELETE USER
    $scope.deleteUserCancel = function () {
        document.getElementById("deleteuser").style.display = "none";
    };

});




