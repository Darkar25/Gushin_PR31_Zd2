using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaraphonSkills.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewerMenuPage.xaml
    /// </summary>
    public partial class ViewerMenuPage : Page
    {
        int picturePageNumber;
        int maxPicturePageNumber;
        Core.user3Entities context;
        public ViewerMenuPage()
        {
            context = new Core.user3Entities();

            InitializeComponent();

            picturePageNumber = 1;
            maxPicturePageNumber = context.Runner.ToList().Count/4;

            if(context.Runner.ToList().Count % 4 > 0)
            {
                maxPicturePageNumber++;
            }

            PictureListView.ItemsSource = context.Runner.OrderBy(x=>x.RunnerId).Take(4).ToList();

            PageCountTextBlock.Text = String.Format("{0} из {1}", picturePageNumber, maxPicturePageNumber);
        }


        /// <summary>
        /// Кнопка перехода на страницу назад в просмотре изображений бегунов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (picturePageNumber > 1)
            {
                picturePageNumber -= 1;
                PictureListView.ItemsSource = context.Runner.OrderBy(x => x.RunnerId).Skip((picturePageNumber-1)*4).Take(4).ToList();
                
                PageCountTextBlock.Text = String.Format("{0} из {1}", picturePageNumber, maxPicturePageNumber);
            }
        }

        /// <summary>
        /// Кнопка перехода на следующую страницу в просмотре изображений бегунов 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (picturePageNumber < maxPicturePageNumber)
            {
                picturePageNumber += 1;
                PictureListView.ItemsSource = context.Runner.OrderBy(x => x.RunnerId).Skip((picturePageNumber-1)*4).Take(4).ToList();
                PageCountTextBlock.Text = String.Format("{0} из {1}", picturePageNumber, maxPicturePageNumber);
            }
        }

        /// <summary>
        /// Кнопка Оставить отзыв
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCommentButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new AddReviewPage());
        }

        /// <summary>
        /// Нажатие на кнопку вывода статистики отзывов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentStatButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new ReviewsPage());
        }
    }
}
