using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using PMOApp.Models;

namespace PMOApp.Views.MainUploadImage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainUpload : ContentPage
    {

        //untukSnap Gambar
        FileAttach Obj;
        private int workID;

        public string filetype;
        public string filetypeID;
        public string name;
        public string imageStr;
        public int ModeSystem;

        public string filenamePenuh;

        public string filealbum;
        public string pathdevice;
        public MainUpload()
        {
            InitializeComponent();
            PopulateImageUpload();
        }

        #region"Button"
        private async void btnBack_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainDashboard.MainDashboard());
        }
        #endregion"Button"

        #region"Imageupload"
        public void PopulateImageUpload()
        {
            btnPlhGambar.Clicked += async (sender, args) =>
            {
                MyLabel.Text = "";
                imgUpload.Source = null;
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {

                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

                });

                if (file == null)
                    return;
                using (var memoryStream = new MemoryStream())
                {
                    file.GetStream().CopyTo(memoryStream);
                    imageStr = Convert.ToBase64String(memoryStream.ToArray());
                }

                filetypeID = "45";
                filetype = "image/jpg";
                name = Path.GetFileNameWithoutExtension(@file.Path);
                filenamePenuh = Path.GetFileName(@file.Path);
                MyLabel.Text = filenamePenuh;

                Obj = null;
                Obj = new FileAttach
                {
                    Id = 0,
                    WorkOrderId = workID,
                    Name = name,
                    FileName = filenamePenuh, // hantar yang ni
                    FileType = filetype,
                    FileTypeId = filetypeID,
                    Description = "",
                    CreatedDate = System.DateTime.Now.ToString("yyyy-MM-dd"),
                    UrlPath = "~\\WorkOrder_Files",
                    ModifiedDate = System.DateTime.Now.ToString("yyyy-MM-dd"),
                    ImageBinary = imageStr
                };
                imgUpload.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };

            btnSnapPic.Clicked += async (sender, args) =>
            {
                MyLabel.Text = "";
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Test",
                    SaveToAlbum = true,
                    CompressionQuality = 75,
                    CustomPhotoSize = 50,
                    PhotoSize = PhotoSize.Small,
                    MaxWidthHeight = 2000,
                    DefaultCamera = CameraDevice.Front

                });


                if (file == null)
                {
                    return;

                }

                using (var memoryStream = new MemoryStream())
                {
                    //file.GetStream().CopyTo(memoryStream);
                    //imageStr = Convert.ToBase64String(memoryStream.ToArray());
                    var stream = file.GetStream();
                    var bytes = new byte[stream.Length];
                    await stream.ReadAsync(bytes, 0, (int)stream.Length);
                    imageStr = Convert.ToBase64String(bytes);  //masa amik gambar convert sini
                }
                filetypeID = "45";
                filetype = "image/jpg";
                name = Path.GetFileNameWithoutExtension(@file.Path);
                filenamePenuh = Path.GetFileName(@file.Path);
                MyLabel.Text = filenamePenuh;
                Obj = null;
                Obj = new FileAttach
                {
                    Id = 0,
                    WorkOrderId = workID,
                    Name = name,
                    FileName = filenamePenuh,
                    FileType = filetype,
                    FileTypeId = filetypeID,
                    Description = "",
                    CreatedDate = System.DateTime.Now.ToString("yyyy-MM-dd"),
                    UrlPath = "~\\WorkOrder_Files",
                    ModifiedDate = System.DateTime.Now.ToString("yyyy-MM-dd"),
                    ImageBinary = imageStr
                };
                imgUpload.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };

        }
        #endregion"ImageUpload"



    }
}