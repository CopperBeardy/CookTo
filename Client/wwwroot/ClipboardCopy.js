

window.clipboardCopy = {
    copyText: function (codeElement) {
        navigator.clipboard.writeText(codeElement).then(function () {
          
        })
            .catch(function (error) {
                alert(error);
            });
    }
}