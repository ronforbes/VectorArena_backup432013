using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MonoGame.Framework;


namespace VectorArenaWin8
{
    /// <summary>
    /// The root page used to display the game.
    /// </summary>
    public sealed partial class GamePage : SwapChainBackgroundPanel
    {
        readonly Game _game;

        public GamePage(string launchArguments)
        {
            this.InitializeComponent();

            // Create the game.
            _game = XamlGame<Game>.Create(launchArguments, Window.Current.CoreWindow, this);
        }
    }
}
