using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace TutorialGame
{
    public abstract class GameLoop
    {

        public const int TARGET_FPS = 60;
        public const float TIME_UNTIL_UPDATE = 1f / TARGET_FPS;

        public RenderWindow Window
        {
            get;
            protected set;
        }

        public GameTime GameTime
        {
            get;
            protected set;
        }

        //color that will display in a window when there is nothing
        public Color WindowClearColor
        {
            get;
            protected set;
        }

        public GameLoop(uint windowWidth, uint windowHeight, string windowTitle, Color windowClearColor)
        {
            this.WindowClearColor = windowClearColor;
            this.Window = new RenderWindow(new VideoMode(windowWidth, windowHeight), windowTitle);
            this.GameTime = new GameTime();
            Window.Closed += WindowClosed;
        }

        private void WindowClosed(object sender, EventArgs e) {
            Window.Close();
        }

        public void Run() {

            LoadContent();
            Initialize();

            float totalTimeBeforeUpdate = 0f;
            float previousTimeElpsed = 0f;
            float deltaTime = 0f;
            float totalTimeElapsed = 0f;

            Clock clock = new Clock(); //starts automatically

            while (Window.IsOpen) {
                Window.DispatchEvents();

                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previousTimeElpsed;
                previousTimeElpsed = totalTimeElapsed;

                totalTimeBeforeUpdate += deltaTime;

                if(totalTimeBeforeUpdate >= TIME_UNTIL_UPDATE) {
                    GameTime.Update(totalTimeBeforeUpdate, clock.ElapsedTime.AsSeconds());
                    totalTimeBeforeUpdate = 0f;

                    Update(GameTime);

                    Window.Clear(WindowClearColor);
                    Draw(GameTime);
                    Window.Display();

                }
            }
        }

        public abstract void LoadContent();
        public abstract void Initialize();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
