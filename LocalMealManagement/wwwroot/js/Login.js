function Login() {
    var username = document.getElementById("username");
    var password = document.getElementById("password");
    var LoginViewModel = {
        Email: username.value,
        Password: password.value,
        RemeberMe: true
    }

    $.ajax({
        type: "POST",
        url: '/Users/Login',
        data: { model: LoginViewModel },
        datatype: String,
        success: function (response) {
            if (response.result == 'Redirect')
                window.location = response.url;
        },
        error: function (response) {
            alert("Username or password do not match!");
        }
    })
}