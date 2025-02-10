namespace SlideMenuBarExample.Commands.Interfaces
{
    public interface IWindowService
    {
        /// <summary>
        /// 사업장 선택 창을 모달로 띄워서 선태 결과를 반환환다.
        /// </summary>
        /// <returns></returns>
        Task<int> ShowPlaceSelectWindowAsync();
    }
}
