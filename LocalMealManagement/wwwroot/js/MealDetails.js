function show(subGroupID, groupid, Date) {
    console.log(subGroupID, groupid, Date);
    $.ajax({
        type: "GET",
        url: '/GroupAdministration/ShowMeal',
        data: { groupId :  groupid.substring(1), subGroupId : subGroupID.substring(1), date : Date.substring(1) },
        datatype: Object,
        success: function (response) {
            console.log(response);
            var result = Object(response);
            console.log(result.dinnar);
            alert("Your Meals : Morning : " + result.morning + " Dinnar: " + result.dinnar + " Lunch: " + result.lunch);
            // console.log("Hello");    
        },
        error: function (response) {
            alert("Somethings Went Wrong!");
        }
    })
};