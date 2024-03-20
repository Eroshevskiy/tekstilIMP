using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static tekstil_profi_m.pages.nackladn;

namespace tekstil_profi_m.pages
{
    /// <summary>
    /// Логика взаимодействия для pechNacladn.xaml
    /// </summary>
    public partial class pechNacladn : Window
    {
        private ObservableCollection<nackladn.OrderItem> orderItems;
        private int OrderItemCount => orderItems.Count;

        public pechNacladn(ObservableCollection<nackladn.OrderItem> orderItems)
        {
            InitializeComponent();
            this.orderItems = orderItems;
            OrderLV.ItemsSource = orderItems;
            
        }

        private void ydalClick(object sender, RoutedEventArgs e)
        {
            if (OrderLV.SelectedItem != null)
            {
                OrderItem selectedOrderItem = OrderLV.SelectedItem as OrderItem;
                if (selectedOrderItem != null)
                {
                    orderItems.Remove(selectedOrderItem);
                    
                }
            }
        }

        private void PrintButton(object sender, RoutedEventArgs e)
        {

        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)this.ActualWidth, (int)this.ActualHeight, 96, 96, PixelFormats.Pbgra32);
    renderTargetBitmap.Render(this);

    // Создаем Image, чтобы отобразить RenderTargetBitmap
    Image image = new Image();
    image.Source = renderTargetBitmap;

    // Создаем PrintDialog для печати
    PrintDialog printDialog = new PrintDialog();

    if (printDialog.ShowDialog() == true)
    {
        // Устанавливаем ориентацию печати на горизонтальную
        printDialog.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;

        // Печать изображения
        printDialog.PrintVisual(image, "Print Page");

        // Если вы также хотите сохранить изображение, то можно использовать следующий код:
        // SaveImage(renderTargetBitmap);
    }



        }

        private void SaveImage(RenderTargetBitmap renderTargetBitmap)
        {
            // Создаем кодек для сохранения изображения
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            // Сохраняем изображение
            using (FileStream stream = new FileStream("page_image.png", FileMode.Create))
            {
                encoder.Save(stream);
            }
        }


    }
}
