document.addEventListener('DOMContentLoaded', () => {
  window.Cropper = null;

  window.InitCropper = (imageUrl) => {
    const div = document.querySelector('#image-crop');

    window.Cropper = new Croppie(div, {
      viewport: { width: 390, height: 300 },
      boundary: { width: 400, height: 400 },
      showZoomer: false,
      enableOrientation: false
    });

    const onLeaveImageArea = () => {
      window.Cropper.result('base64').then(function(blob) {
        window.Cropper.finalResult = blob;
      });
    }

    window.Cropper.GetFinalResult = () => {
      div.removeEventListener('mouseleave', onLeaveImageArea, false);
      window.Cropper.destroy();
      return window.Cropper.finalResult;
    };

    window.Cropper.bind({
      url: imageUrl
    });

    div.addEventListener('mouseleave', onLeaveImageArea, false);
  }
});
