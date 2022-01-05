function is32Bit() {
    requires64bit = false
    if (navigator.userAgent.indexOf("WOW64") != -1 || 
    navigator.userAgent.indexOf("Win64") != -1 ){
    requires64bit = true
    } else {
    requires64bit = false
    }

    console.log(requires64bit);
    downloadRequiredInstaller(requires64bit);
}

function downloadRequiredInstaller(architecture) {
    if (architecture == true) {
        window.location.href = "http://cipher.hattangadi.com/cdn/novafoldercreator/downloads/novafoldercreator-latest-64-bit.zip"
    } else {
        window.location.href = "http://cipher.hattangadi.com/cdn/novafoldercreator/downloads/novafoldercreator-latest-32-bit.zip"
    }
}

function close() {
    win = window.open("");
    win.close();
}