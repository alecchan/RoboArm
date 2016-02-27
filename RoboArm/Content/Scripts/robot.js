(function () {

    var isRecording = false;
    var history = [];

    function clearHistory() {
        history = [];
    }

    function addHistory(cmd) {
        history.push(cmd);
    }
    
    function getLibrary() {
        var library = localStorage.getItem("library");

        if (!library) {
            library = {};
        }
    }

    function saveHistory(name) {
        var library = getLibrary();
        library[name] = history;

        localStorage.setItem("library", library);
    }

    function loadTape(name) {
        var library = getLibrary();
        var tape = library[name];
    }

    function armCommand() {
        var id = this.id
        addHistory(id);

        var data = JSON.stringify({ "action": id });
        $.ajax({
            type: "POST",
            url: "/robotarm",
            data: data,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json'
        });
    }

    function rewind() {

        if (history.length > 0) {
            var data = JSON.stringify( history );
            $.ajax({
                type: "POST",
                url: "/robotarm/reset",
                data: data,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json'
            }).done(function (data) {
                clearHistory();
            });
        }
    }


    function initilise() {
        $(".arm-ctrls button").click(armCommand);

        $("#rewind").click(rewind);
    }

    initilise();

}());