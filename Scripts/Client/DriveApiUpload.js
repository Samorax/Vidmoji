document.addEventListener("DOMContentLoaded", DriveButtonTrigger, false);


function DriveButtonTrigger() {

    var developerKey = "AIzaSyDQVT_RXlgK8tWk9I96FEW86AU1uTPa4kQ";
    var clientId = "530680560329-log6nesf0ekk1tta07jeen65q794uqde.apps.googleusercontent.com";

    // Scope to use to access user's photos.
    var scope = ['https://www.googleapis.com/auth/drive.readonly'];

    var pickerApiLoaded = false;
    var oauthToken;

    document.getElementById("driveUpload").onclick = function () { onApiLoad()};
    // Use the API Loader script to load google.picker and gapi.auth.
    function onApiLoad() {
        gapi.load('auth', { 'callback': onAuthApiLoad });
        gapi.load('picker', { 'callback': onPickerApiLoad });
    }

    function onAuthApiLoad() {
        window.gapi.auth.authorize(
            {
                'client_id': clientId,
                'scope': scope,
                'immediate': false
            },
            handleAuthResult);
    }

    function onPickerApiLoad() {
        pickerApiLoaded = true;
        createPicker();
    }

    function handleAuthResult(authResult) {
        if (authResult && !authResult.error) {
            oauthToken = authResult.access_token;
            createPicker();
        }
    }

    // Create and render a Picker object for picking user Photos.
    function createPicker() {
        if (pickerApiLoaded && oauthToken) {
            var picker = new google.picker.PickerBuilder().
                addView(google.picker.ViewId.DOCS).
                setOAuthToken(oauthToken).
                setDeveloperKey(developerKey).
                setCallback(pickerCallback).
                build();
            picker.setVisible(true);
        }
    }

    // A simple callback implementation.
    function pickerCallback(data) {
        var url = 'nothing';
        if (data[google.picker.Response.ACTION] == google.picker.Action.PICKED) {
            var doc = data[google.picker.Response.DOCUMENTS][0];
            //url = doc[google.picker.Document.URL];
            $.ajax({ type:POST, data: doc, url: "/DriveChopUpload", success: function () { console.log("Its been done.") } });
            //console.log(doc);
        }
        
    }
}