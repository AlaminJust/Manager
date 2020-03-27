
function saveBalance(userName, subGroupId, groupid) {
    if (!confirm("Are You Sure About this Action?")) return;
    var xx = document.getElementById(userName.substring(1));
    var AccountViewModel = {
        Taka: parseFloat(xx.value),
        groupId: groupid.substring(1),
        subGroupId: subGroupId.substring(1),
        UserName: userName.substring(1)
    }
    xx.value = "0";
    var jsonData = AccountViewModel;
    // console.log(jsonData);
    $.ajax({
        type: "POST",
        url: '/Account/AddBalance',
        data: { model: jsonData },
        datatype: AccountViewModel,
        success: function (response) {
            //console.log(response.userName);
            alert("Balanced Added Succesfully to " + response.userName);
            // console.log("Hello");
        },
        error: function (response) {
            alert("Somethings Went Wrong!");
        }
    })
};

function pulsar(obj) {
    obj.value = Math.abs(parseFloat(obj.value));
    console.log(obj.value);
    if (obj.value == "NaN") obj.value = "0";
}

