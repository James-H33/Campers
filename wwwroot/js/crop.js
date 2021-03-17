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
        const result = {
          Image: '',
          Thumbnail: ''
        };

        const HighRes = () => {
          return new Promise(resolve => {
            window.Cropper.result({ type: 'base64', size: { width: 500, height: 400 } }).then((blob) => {
              resolve(blob);
            });
          });
        }

        const Thumbnail = () => {
          return new Promise(resolve => {
            window.Cropper.result({ type: 'base64', size: { width: 300, height: 200 } }).then((blob) => {
              resolve(blob);
            });
          });
        }

        return new Promise(async (resolve) => {
          const [image, thumbnail] = await Promise.all([HighRes(), Thumbnail()]);
          result.Image = image;
          result.Thumbnail = thumbnail;
          debugger;
          window.Cropper.destroy();
          window.Cropper = null;
          resolve(result);
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
