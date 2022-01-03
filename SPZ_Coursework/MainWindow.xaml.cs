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
using WPFWork.Model;
using System.IO;



namespace WPFWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int pointIndex = 0;
        Point currentPoint = new Point();
        int cnt = 0;
        Line currentlyLine = null;
        Wall wall = null;
        bool wallClick = false;
        bool windowClick = false;
        bool doorClick = false;
        bool doorwayClick = false;
        bool bathClick = false;
        bool stoveClick = false;
        bool toiletClick = false;

        Rectangle dottedRectangle = null;
        Ellipse ellipse1 = null;
        Ellipse ellipse2 = null;

        Stove currentStove = null;
        Bath currentBath = null;
        Door currentDoor = null;
        UWindow currentWindow = null;
        Toilet currentToilet = null;
        Doorway currentDoorway = null;
        Wall currentWall = null;

        List<Bath> baths = new List<Bath>();
        List<Stove> stoves = new List<Stove>();
        List<Door> doors = new List<Door>();
        List<Toilet> toilets = new List<Toilet>();
        List<UWindow> windows = new List<UWindow>();
        List<Doorway> doorways = new List<Doorway>();
        List<Wall> walls = new List<Wall>();

        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void ThereIsCurrentLine(MouseEventArgs e, ref double markerX, ref double markerY)
        {
            if(ellipse1 != null && ellipse2 != null)
            {
                if (pointIndex == 0)
                {
                    currentlyLine.X1 = e.GetPosition(g).X;
                    currentlyLine.Y1 = e.GetPosition(g).Y;
                    markerX = currentlyLine.X1;
                    markerY = currentlyLine.Y1;
                    Canvas.SetLeft(ellipse1, markerX - 5);
                    Canvas.SetTop(ellipse1, markerY - 5);
                }
                else
                {
                    currentlyLine.X2 = e.GetPosition(g).X;
                    currentlyLine.Y2 = e.GetPosition(g).Y;
                    markerX = currentlyLine.X2;
                    markerY = currentlyLine.Y2;
                    Canvas.SetLeft(ellipse2, markerX - 5);
                    Canvas.SetTop(ellipse2, markerY - 5);
                }
            }
        }
        private void NoPressed(MouseEventArgs e, ref double markerX, ref double markerY)
        {
            foreach (Line line1 in g.Children.OfType<Line>())
            {
             
                if (Math.Abs(line1.X1 - e.GetPosition(g).X) < 5 && Math.Abs(line1.Y1 - e.GetPosition(g).Y) < 5)
                {
                    pointIndex = 0;
                    markerX = line1.X1;
                    markerY = line1.Y1;
                    currentlyLine = line1;
                }
                else if (Math.Abs(line1.X2 - e.GetPosition(g).X) < 5 && Math.Abs(line1.Y2 - e.GetPosition(g).Y) < 5)
                {
                    pointIndex = 1;
                    markerX = line1.X2;
                    markerY = line1.Y2;
                    currentlyLine = line1;
                }
            }
        }
       
        private void MoveDottedRectangle(double x, double y)
        {
            Canvas.SetLeft(dottedRectangle, x - dottedRectangle.Margin.Left);
            Canvas.SetTop(dottedRectangle, y - dottedRectangle.Margin.Top);
        }
        private void g_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (currentDoor != null)
            {
                if (e.LeftButton == MouseButtonState.Pressed && dottedRectangle != null)
                {
                    currentDoor.Move(e.GetPosition(g).X + 5, e.GetPosition(g).Y + 5);
                    MoveDottedRectangle(e.GetPosition(g).X, e.GetPosition(g).Y);
                }
            }
            if(currentBath != null)
            {
               if (e.LeftButton == MouseButtonState.Pressed && dottedRectangle != null)
                {
                    currentBath.Move(e.GetPosition(g).X + 5, e.GetPosition(g).Y + 5);
                    MoveDottedRectangle(e.GetPosition(g).X, e.GetPosition(g).Y);
                }
            }
            if (currentToilet != null)
            {
                if (e.LeftButton == MouseButtonState.Pressed && dottedRectangle != null)
                {
                    currentToilet.Move(e.GetPosition(g).X + 5, e.GetPosition(g).Y + 5);
                    MoveDottedRectangle(e.GetPosition(g).X, e.GetPosition(g).Y);
                }
            }
            if (currentWindow != null)
            {
                if (e.LeftButton == MouseButtonState.Pressed && dottedRectangle != null)
                {
                    currentWindow.Move(e.GetPosition(g).X + 5, e.GetPosition(g).Y + 5);
                    MoveDottedRectangle(e.GetPosition(g).X, e.GetPosition(g).Y);
                }
            }
            if (currentStove != null)
            {
                if (e.LeftButton == MouseButtonState.Pressed && dottedRectangle != null)
                {
                    currentStove.Move(e.GetPosition(g).X + 5, e.GetPosition(g).Y + 5);
                    MoveDottedRectangle(e.GetPosition(g).X, e.GetPosition(g).Y);
                }
            }
            if (currentDoorway != null)
            {
                if (e.LeftButton == MouseButtonState.Pressed && dottedRectangle != null)
                {
                    currentDoorway.Move(e.GetPosition(g).X + 5, e.GetPosition(g).Y + 5);
                    MoveDottedRectangle(e.GetPosition(g).X, e.GetPosition(g).Y);
                }
            }
         

            if (wallClick)
            {
               
                double markerX = -1, markerY = -1;
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Line line = null;
                    if (currentlyLine != null)
                    {
                        ThereIsCurrentLine(e, ref markerX, ref markerY);
                        return;
                    }
                    else
                    {
                        foreach (Line line1 in g.Children.OfType<Line>())
                        {
                            line = line1;
                            if (line.Name == "line_" + cnt)
                            {
                                break;
                            }
                            else line = null;
                        }
                    }
                    if (currentlyLine == null)
                    {
                        if (line == null)
                        {
                            wall = new Wall(Brushes.Gray, currentPoint.X, currentPoint.Y, e.GetPosition(g).X, e.GetPosition(g).Y);
                            line = wall.line;
                            currentPoint = e.GetPosition(g);
                            line.Name = "line_" + cnt;
                            g.Children.Add(line);
                            walls.Add(wall);
                        }
                        else
                        {
                            line.X2 = e.GetPosition(g).X;
                            line.Y2 = e.GetPosition(g).Y;
                            g.InvalidateVisual();
                        }
                    }
                }
                else
                {
                    NoPressed(e, ref markerX, ref markerY);
                }
                if(markerX == -1)
                {
                    if (e.LeftButton != MouseButtonState.Pressed)
                    {
                        currentlyLine = null;
                    }   
                    g.InvalidateVisual();     
                }
              
            }
        }

        private void g_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (wallClick)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    currentPoint = e.GetPosition(g);//точка в которую кликаем первый раз
            }
            double x = e.GetPosition(g).X;
            double y = e.GetPosition(g).Y;
            
                var children = g.Children.OfType<Ellipse>().Where(item => item.Fill == Brushes.Transparent).ToList();
                foreach (Ellipse ell in children)
                {
                    g.Children.Remove(ell);
                }
                foreach (var wl in walls)
                {
                    Wall findWall = wl.FindItem(x, y);
                    bool condition = (ellipse1 != null && ellipse2 != null);
                    if (findWall == null && condition)
                    {
                        g.Children.Remove(ellipse1);
                        g.Children.Remove(ellipse2);
                        ellipse1 = null;
                        ellipse2 = null;
                        currentWall = null;
                        continue;
                    }
                    if (currentWall != findWall && condition)
                    {
                        g.Children.Remove(ellipse1);
                        ellipse1 = null;
                        ellipse2 = null;
                        currentWall = null;
                        continue;
                    }
                    wl.Highlight(x, y, ref ellipse1, ref ellipse2);
                    if (ellipse1 != null && ellipse2 != null)
                    {
                        g.Children.Add(ellipse1);
                        g.Children.Add(ellipse2);
                        NullAll();
                        currentWall = findWall;
                        return;
                    }
                
            }
        }

        
        private void g_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            double x = e.GetPosition(g).X;
            double y = e.GetPosition(g).Y;
            var children = g.Children.OfType<Rectangle>().Where(item => item.StrokeDashArray.Count != 0).ToList();
            foreach (Rectangle rect in children)
            {
                g.Children.Remove(rect);
            }
           
            foreach (var s in stoves)
            {
                Stove findStove = s.FindItem(x, y);
                
                if ((findStove == null || currentStove != findStove) && dottedRectangle != null)
                {
                    g.Children.Remove(dottedRectangle);
                    dottedRectangle = null;
                    currentStove = null;
                    continue;
                }
                dottedRectangle = s.Highlight(x, y);
                if (dottedRectangle != null)
                {
                    g.Children.Add(dottedRectangle);
                    NullAll();
                    currentStove = findStove;
                    return;
                }  
            }

            foreach (var b in baths)
            {
                Bath findBath = b.FindItem(x, y);
                if ((findBath == null || currentBath != findBath) && dottedRectangle != null)
                {
                    g.Children.Remove(dottedRectangle);
                    dottedRectangle = null;
                    currentBath = null;
                    continue;
                }
                dottedRectangle = b.Highlight(x, y);
                if (dottedRectangle != null)
                {
                    g.Children.Add(dottedRectangle);
                    NullAll();
                    currentBath = findBath;
                    return;
                }
            }

            foreach (var d in doors)
            {
                Door findDoor = d.FindItem(x, y); 
                if ((findDoor == null || currentDoor != findDoor) && dottedRectangle != null)
                {
                    g.Children.Remove(dottedRectangle);
                    dottedRectangle = null;
                    currentDoor = null;
                    continue;
                }
                dottedRectangle = d.Highlight(x, y);
                if (dottedRectangle != null)
                {
                    g.Children.Add(dottedRectangle);
                    NullAll();
                    currentDoor = findDoor;
                    return;
                }
            }

            foreach (var t in toilets)
            {
                Toilet findToilet = t.FindItem(x, y);
                if ((findToilet == null || currentToilet != findToilet) && dottedRectangle != null)
                {
                    g.Children.Remove(dottedRectangle);
                    dottedRectangle = null;
                    currentToilet = null;
                    continue;
                }
                dottedRectangle = t.Highlight(x, y);
                if (dottedRectangle != null)
                {
                    NullAll();
                    g.Children.Add(dottedRectangle);
                    currentToilet = findToilet;
                    return;
                }
            }

            foreach (var w in windows)
            {
                UWindow findWindow = w.FindItem(x, y);
                if ((findWindow == null || currentWindow != findWindow) && dottedRectangle != null)
                {
                    g.Children.Remove(dottedRectangle);
                    dottedRectangle = null;
                    currentWindow = null;
                    continue;
                }
                dottedRectangle = w.Highlight(x, y);
                if (dottedRectangle != null)
                {
                    g.Children.Add(dottedRectangle);
                    NullAll();
                    currentWindow = findWindow;
                    return;
                }
            }

            foreach (var dw in doorways)
            {
                Doorway findDoor = dw.FindItem(x, y);
                if ((findDoor == null || currentDoorway != findDoor) && dottedRectangle != null)
                {
                    g.Children.Remove(dottedRectangle);
                    dottedRectangle = null;
                    currentDoorway = null;
                    continue;
                }

                dottedRectangle = dw.Highlight(x, y);
                if (dottedRectangle != null)
                {
                    g.Children.Add(dottedRectangle);
                    NullAll();
                    currentDoorway = findDoor;
                    return;
                }
            }


            if (wallClick)
            {
                cnt++;
            }

            else if (doorClick)
            {
                Door door = new Door(40, x, y);
                AddDoor(door);
                doorClick = false;
            }
            else if (doorwayClick)
            {
                Doorway doorway = new Doorway(40, x, y);
                AddDoorway(doorway);
                doorwayClick = false;
            }
            else if (windowClick)
            {
                UWindow window = new UWindow(40, x, y);
                AddWindow(window);
                windowClick = false;
            }
            else if (toiletClick)
            {
                Toilet toilet = new Toilet(x, y);
                AddToilet(toilet);
                toiletClick = false;
            }
            else if (stoveClick)
            {
                Stove stove = new Stove(x, y);
                g.Children.Add(stove.rectangle);
                for (int i = 0; i < 4; i++)
                {
                    g.Children.Add(stove[i]);
                }
                stoves.Add(stove);
                g.InvalidateVisual();
                stoveClick = false;
            }
            else if (bathClick)
            {
                Bath bath = new Bath(x, y);
                AddBath(bath);
                bathClick = false;
            }

        }
      
        bool FalseAll()
        {
            wallClick = false;
            windowClick = false;
            doorClick = false;
            doorwayClick = false;
            bathClick = false;
            stoveClick = false;
            toiletClick = false;

            return true;
        }
        private void NullAll()
        {
            currentDoorway = null;
            currentDoor = null;
            currentBath = null;
            currentStove = null;
            currentWindow = null;
            currentToilet = null;
            currentWall = null;
        }
        private void doorway_Click(object sender, RoutedEventArgs e)
        {
            doorwayClick = FalseAll();
        }

        private void doorButton_Click(object sender, RoutedEventArgs e)
        {
            doorClick = FalseAll();
        }

        private void windowButton_Click(object sender, RoutedEventArgs e)
        {
            windowClick = FalseAll();
        }

        private void toiletButton_Click(object sender, RoutedEventArgs e)
        {
            toiletClick = FalseAll();
        }

        private void stoveButton_Click(object sender, RoutedEventArgs e)
        {
            stoveClick = FalseAll();
        }

        private void bathButton_Click(object sender, RoutedEventArgs e)
        {
            bathClick = FalseAll();
        }
        
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dottedRectangle != null)
            {
                if(currentStove != null)
                {
                    DeleteStove();
                    currentStove = null;
                    g.InvalidateVisual();
                }
                if (currentBath != null)
                {
                    DeleteBath();
                    currentBath = null;
                    g.InvalidateVisual();
                }
                if(currentDoor != null)
                {
                    DeleteDoor();
                    currentDoor = null;
                    g.InvalidateVisual();
                }
                if (currentToilet != null)
                {
                    DeleteToilet();
                    currentToilet = null;
                    g.InvalidateVisual();
                }
                if (currentWindow != null)
                {
                    DeleteWindow();
                    currentWindow = null;
                    g.InvalidateVisual();
                }
                if (currentDoorway != null)
                {
                    DeleteDoorway();
                    currentDoorway = null;
                    g.InvalidateVisual();
                }
            }
            if (currentWall != null)
            {
                DeleteWall();
                currentWall = null;
                g.InvalidateVisual();
            }
        }
        void DeleteDoor()
        {
            g.Children.Remove(currentDoor.rectangle);
            g.Children.Remove(dottedRectangle);
            doors.Remove(currentDoor);
            dottedRectangle = null;
        }
        void DeleteStove()
        {
            for (int i = 0; i < 4; i++)
            {
                g.Children.Remove(currentStove[i]);
            }
            g.Children.Remove(currentStove.rectangle);
            g.Children.Remove(dottedRectangle);
            stoves.Remove(currentStove);
            dottedRectangle = null;
        }
        void DeleteBath()
        {
            g.Children.Remove(currentBath.ellipse);
            g.Children.Remove(currentBath.line1);
            g.Children.Remove(currentBath.line2);
            g.Children.Remove(dottedRectangle);
            baths.Remove(currentBath);
            dottedRectangle = null;
        }
        void DeleteToilet()
        {
            g.Children.Remove(currentToilet.rectangle);
            g.Children.Remove(currentToilet.ellipse);
            g.Children.Remove(dottedRectangle);
            toilets.Remove(currentToilet);
            dottedRectangle = null;
        }
        void DeleteWindow()
        {
            g.Children.Remove(currentWindow.rectangle);
            g.Children.Remove(currentWindow.line1);
            g.Children.Remove(currentWindow.line2);
            g.Children.Remove(dottedRectangle);
            windows.Remove(currentWindow);
            dottedRectangle = null;
        }
        void DeleteDoorway()
        {
            g.Children.Remove(currentDoorway.rectangle);
            for (int i = 0; i < 3; i++)
            {
                g.Children.Remove(currentDoorway[i]);
            }
            g.Children.Remove(dottedRectangle);
            doorways.Remove(currentDoorway);
            dottedRectangle = null;
        }
        void DeleteWall()
        {
            g.Children.Remove(currentWall.line);
            g.Children.Remove(ellipse1);
            g.Children.Remove(ellipse2);
            walls.Remove(currentWall);
            ellipse1 = null;
            ellipse2 = null;
        }
        void AddDoor(Door door)
        {
            doors.Add(door);
            g.Children.Add(door.rectangle);
            g.InvalidateVisual();
        }
        void AddBath(Bath bath)
        {
            baths.Add(bath);
            g.Children.Add(bath.ellipse);
            g.Children.Add(bath.line1);
            g.Children.Add(bath.line2);
            g.InvalidateVisual();
        }
        void AddToilet(Toilet toilet)
        {
            toilets.Add(toilet);
            g.Children.Add(toilet.rectangle);
            g.Children.Add(toilet.ellipse);
            g.InvalidateVisual();
        }
        void AddWindow(UWindow window)
        {
            windows.Add(window);
            g.Children.Add(window.rectangle);
            g.Children.Add(window.line1);
            g.Children.Add(window.line2);
            g.InvalidateVisual();
        }
        void AddDoorway(Doorway doorway)
        {
            g.Children.Add(doorway.rectangle);
            for (int i = 0; i < 3; i++)
            {
                g.Children.Add(doorway[i]);
            }
            g.InvalidateVisual();
            doorways.Add(doorway);
        }

        private void rotateButton_Click(object sender, RoutedEventArgs e)
        {
            if (dottedRectangle != null)
            {
                if (currentDoor != null)
                {
                    DeleteDoor();
                    Door door = currentDoor.Rotate();
                    AddDoor(door);
                    currentDoor = null;
                }
                if (currentBath != null)
                {
                    DeleteBath();
                    Bath bath = currentBath.Rotate();
                    AddBath(bath);
                    currentBath = bath;
                }
                if(currentToilet != null)
                {
                    DeleteToilet();
                    Toilet toilet = currentToilet.Rotate();
                    AddToilet(toilet);
                    currentToilet = toilet;
                }
                if (currentWindow != null)
                {
                    DeleteWindow();
                    UWindow window = currentWindow.Rotate();
                    AddWindow(window);
                    currentWindow = window;
                }
                if (currentDoorway != null)
                {
                    DeleteDoorway();
                    Doorway doorway = currentDoorway.Rotate();
                    AddDoorway(doorway);
                    currentDoorway = doorway;
                }
            }
        }
        private void wall_button_Click(object sender, RoutedEventArgs e)
        {
            wallClick = true;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveimg = new Microsoft.Win32.SaveFileDialog();
            saveimg.DefaultExt = ".PNG";
            saveimg.Filter = "Image (.PNG)|*.PNG";
            if (saveimg.ShowDialog() == true)
            {
                ToImageSource(g, saveimg.FileName);  //DragArena  - имя имеющегося канваса
            }
        }
        private  void ToImageSource(Canvas canvas, string filename)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);
            canvas.Measure(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight));
            canvas.Arrange(new Rect(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight)));
            bmp.Render(canvas);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            using (FileStream file = File.Create(filename))
            {
                encoder.Save(file);
            }
        }
      

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            g.Children.Clear();
            walls.Clear();
            baths.Clear();
            stoves.Clear();
            doors.Clear();
            toilets.Clear();
            windows.Clear();
            doorways.Clear();
        }

        /*private void serializeButton_Click(object sender, RoutedEventArgs e)
        {
            if(walls.Count > 0)
             {
                 serialization.Serialize(pathWall, walls);
             }
            if (baths.Count > 0)
            {
                serialization.Serialize(pathBath, baths);
            }
            if (stoves.Count > 0)
            {
                serialization.Serialize(pathStove, stoves);
            }
            if (doors.Count > 0)
            {
                serialization.Serialize(pathDoor, doors);
            }
            if (toilets.Count > 0)
            {
                serialization.Serialize(pathToilet, toilets);
            }
            if (windows.Count > 0)
            {
                serialization.Serialize(pathWindow, windows);
            }
            if (doorways.Count > 0)
            {
                serialization.Serialize(pathDoorway, doorways);
            }
        }*/
    }
}

