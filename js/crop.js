document.addEventListener('DOMContentLoaded', () => {
  window.Cropper = null;

  window.InitCropper = (imageUrl) => {
    const div = document.querySelector('#image-crop');
    const formContainer = document.querySelector('.create-campground-page');
    const cropperWidth = formContainer.getBoundingClientRect().width;
    const cropperHeight = cropperWidth * .764;

    if (!window.Cropper) {
      window.Cropper = new Croppie(div, {
        viewport: { width: cropperWidth - 20, height: cropperHeight - 20 },
        boundary: { width: cropperWidth, height: cropperHeight },
        showZoomer: true,
        enableOrientation: false
      });

      window.Cropper.GetFinalResult = () => {
        return new Promise((resolve) => {
          window.Cropper.result({ type: 'base64', size: { width: 800, height: 600 } }).then((blob) => {
            window.Cropper.destroy();
            window.Cropper = null;
            resolve(blob);
          });
        });
      }

      window.Cropper.bind({
        url: imageUrl
      });
    } else {
      window.Cropper.bind({
        url: imageUrl
      });
    }
  }
});
