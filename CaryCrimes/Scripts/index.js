var vm = vm || {};
vm.crimeData = null;
vm.crimeCategory = null;
vm.map = null;

function addPushPin(element) {
    var point = new Array(new VELatLong(element.Lat, element.Lon));
    var myPushpin = new VEShape(VEShapeType.Pushpin, point);
    var points = new Array();
    points.push(myPushpin);
    myPushpin.SetTitle("Street:" + element.Street + "\n Date:" + element.IncidentDate);
    myPushpin.SetDescription(element.Category);
    vm.map.AddShape(myPushpin);
    vm.map.SetMapView(points);
}

function updateMap() {
    $.getJSON('/api/crime', { "category": vm.crimeCategory }, function (data) {
        vm.crimeData = data;
        vm.map.DeleteAllShapeLayers();
        $.each(data, function(i,element) {
            addPushPin(element);
        });
    });

}


vm.onCategoryChanged = function() {
   updateMap();
};

vm.getCrimeData= function() {
    
    $.getJSON('/api/category', function (data) {
        vm.crimeCategory = data;
        ko.applyBindings(vm);
    });
   
};
function docReady() {
    vm.getCrimeData();
    vm.map = new VEMap('myMap');
    vm.map.LoadMap();
}

$(docReady);