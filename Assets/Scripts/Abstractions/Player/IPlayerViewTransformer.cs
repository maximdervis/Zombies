namespace Abstractions.Player
{
    public interface IPlayerViewTransformer : IPlayerViewHorizontalScroller, IPlayerViewVerticalScroller
    {
        void ZoomIn();
        void ZoomOut();
        void EnableKickBack(); 
    }
}