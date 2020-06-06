using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using TutorialGame.Game;

namespace TutorialGame {
    public class TutorialGame : GameLoop {

        public const uint DEFAULT_WINDOW_WIDTH = 640;
        public const uint DEFAULT_WINDOW_HEIGHT = 480;
        public const string WINDOW_TITLE = "Tutorial Game";
        public TutorialGame() : base (DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT, WINDOW_TITLE, Color.Black) {

        }

        public override void Draw(GameTime gameTime) {
            DebugUtility.DrawPerfomanceData(this, Color.White);
        }

        public override void Initialize() {
        }

        public override void LoadContent() {
            DebugUtility.LoadContent();
        }

        public override void Update(GameTime gameTime) {
        }
    }
}
