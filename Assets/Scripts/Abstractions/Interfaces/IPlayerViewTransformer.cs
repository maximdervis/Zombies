namespace Abstractions.Interfaces
{
    public interface IPlayerViewTransformer : IPlayerViewHorizontalScroller, IPlayerViewVerticalScroller
    {
        void ZoomIn();
        void ZoomOut();
    }
}