using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portals
{
    public enum GameState : short { MainMenu = 1, Credits, ChooseLevel, Playing , Quit }
    public enum PortalState : short { OnScreen, OffScreen };
    public enum ObstacleType : short { Vertical, Horizontal }
    public enum PortalShape : short { Horizontal, Vertical }

}
