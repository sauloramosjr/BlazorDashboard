window.getGeolocation = function() {
    return new Promise((resolve, reject) => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                position => {
                    resolve({
                        latitude: position.coords.latitude,
                        longitude: position.coords.longitude
                    });
                },
                error => {
                    reject(error.message); // Passa a mensagem de erro
                }
            );
        } else {
            reject("Geolocalização não é suportada neste navegador.");
        }
    });
};

let videoElement;
let canvasElement;
let canvasContext;

window.startCamera = function(videoId='videoElement') {
    videoElement = document.getElementById(videoId);
    navigator.mediaDevices.getUserMedia({ video: true })
        .then((stream) => {
            videoElement.srcObject = stream;
            videoElement.play();
        })
        .catch((err) => {
            console.error("Error accessing camera: ", err);
        });
}

function capturePhotoToAdd(src, dest, dotNetHelper)  {
    console.log('cadastrando')
    let video = document.getElementById(src);
    let canvas = document.getElementById(dest);
    canvas.getContext('2d').drawImage(video, 0, 0, 320, 240);

    let dataUrl = canvas.toDataURL("image/jpeg");
    dotNetHelper.invokeMethodAsync('CadastrarImageAsync', dataUrl);
};
function capturePhotoToValidate(src, dest, dotNetHelper)  {
    console.log('validando')
    let video = document.getElementById(src);
    let canvas = document.getElementById(dest);
    canvas.getContext('2d').drawImage(video, 0, 0, 320, 240);

    let dataUrl = canvas.toDataURL("image/jpeg");
    dotNetHelper.invokeMethodAsync('ValidateImage', dataUrl);
};

