using PMOApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PMOApp.ViewModels
{
    public  class ImageSliderViewModels : INotifyPropertyChanged
    {
        readonly IList<ImageSlider> source;
        public ObservableCollection<ImageSlider> imageslider { get; private set; }
        public ImageSliderViewModels()
        {
            source = new List<ImageSlider>();
            CreateImageSliderCollection();

        }

        void CreateImageSliderCollection()
        {
            source.Add(new ImageSlider
            {
                imageurl = "image1.png",
                context = "Mindwave UI Apps One",
                textbutton = "CLICK TO VIEW"
            });
            source.Add(new ImageSlider
            {
                imageurl = "image2.png",
                context = "Mindwave UI Apps Two",
                textbutton = "CLICK TO VIEW"
            });
            source.Add(new ImageSlider
            {
                imageurl = "image3.png",
                context = "Mindwave UI Apps Three",
                textbutton = "CLICK TO VIEW"
            });
            imageslider = new ObservableCollection<ImageSlider>(source);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
