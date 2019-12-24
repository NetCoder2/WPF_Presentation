using System.Windows.Media;

namespace Core
{
    public class DialogInfoViewModel : WindowModel
    {
        /// <summary>
        /// The text of the information
        /// </summary>
        public string InformationText { get; set; }

        public SolidColorBrush FillBrush
        { get; set; } = new SolidColorBrush(Colors.SandyBrown);


    }
}
