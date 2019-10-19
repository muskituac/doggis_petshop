var Index = {

    API_URL: "",

    Initialize: function (api_url) {
        var that = this;

        that.API_URL = api_url;

        that.LoginStart();
    },

    //Método para realizar login
    LoginStart: function () {
        var that = this;

        that.PreProcees();
    },

    PreProcees: function () {
        $("#content_modal").modal({ backdrop: "static", keyboard: false });
        $("#content_modal").modal("show");
    },

}