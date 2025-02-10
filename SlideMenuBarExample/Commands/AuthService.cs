using SlideMenuBarExample.Commands.Interfaces;

namespace SlideMenuBarExample.Commands
{
    public class AuthService : IAuthService
    {
        /// <summary>
        /// 토큰원본
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// 선택된 사업장
        /// </summary>
        public int PlaceId { get; set; }

        /// <summary>
        /// 사업장 명
        /// </summary>
        public string? PlaceName { get; set; }

        /// <summary>
        /// 사업장 생성일
        /// </summary>
        public string? PlaceCreateDT { get; set; }

        /// <summary>
        /// 사용자 인덱스
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 사용자 이름
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// 사용자 타입
        /// </summary>
        public string? UserType { get; set; }

        /// <summary>
        /// 알람 유무
        /// </summary>
        public bool AlarmYN { get; set; }

        /// <summary>
        /// 관리자 유무
        /// </summary>
        public bool AdminYN { get; set; }

        /// <summary>
        /// 권한
        /// </summary>
        public string? Role { get; set; }

        #region 사용자 권한
        /// <summary>
        /// 기본정보 권한
        /// </summary>
        public int UserPerm_Basic { get; set; }

        /// <summary>
        /// 기계관리 권한
        /// </summary>
        public int UserPerm_Machine { get; set; }

        /// <summary>
        /// 전기관리 권한
        /// </summary>
        public int UserPerm_Elec { get; set; }

        /// <summary>
        /// 승강관리 권한
        /// </summary>
        public int UserPerm_Lift { get; set; }

        /// <summary>
        /// 소방관리 권한
        /// </summary>
        public int UserPerm_Fire { get; set; }

        /// <summary>
        /// 건축관리 권한
        /// </summary>
        public int UserPerm_Construct { get; set; }

        /// <summary>
        /// 통신관리 권한
        /// </summary>
        public int UserPerm_Network { get; set; }

        /// <summary>
        /// 미화 권한
        /// </summary>
        public int UserPerm_Beauty { get; set; }

        /// <summary>
        /// 보안 권한
        /// </summary>
        public int UserPerm_Security { get; set; }

        /// <summary>
        /// 자재관리 권한
        /// </summary>
        public int UserPerm_Material { get; set; }

        /// <summary>
        /// 에너지관리 권한
        /// </summary>
        public int UserPerm_Energy { get; set; }

        /// <summary>
        /// 사용자관리 권한
        /// </summary>
        public int UserPerm_User { get; set; }

        /// <summary>
        /// 미원관리 권한
        /// </summary>
        public int UserPerm_Voc { get; set; }
        #endregion

        #region VOC 권한
        /// <summary>
        /// 기계 VOC 권한
        /// </summary>
        public bool VocMachine { get; set; }

        /// <summary>
        /// 전기 VOC 권한
        /// </summary>
        public bool VocElec { get; set; }

        /// <summary>
        /// 승강 VOC 권한
        /// </summary>
        public bool VocLift { get; set; }

        /// <summary>
        /// 소방 VOC 권한
        /// </summary>
        public bool VocFire { get; set; }

        /// <summary>
        /// 건축 VOC 권한
        /// </summary>
        public bool VocConstruct { get; set; }

        /// <summary>
        /// 통신 VOC 권한
        /// </summary>
        public bool VocNetWork { get; set; }

        /// <summary>
        /// 미화 VOC 권한
        /// </summary>
        public bool VocBeauty { get; set; }

        /// <summary>
        /// 보안 VOC 권한
        /// </summary>
        public bool VocSecurity { get; set; }

        /// <summary>
        /// 미분류 VOC 권한
        /// </summary>
        public bool VocDefault { get; set; }
        #endregion

        #region 사업장 권한
        /// <summary>
        /// 사업장 기계 권한
        /// </summary>
        public bool PlacePerm_Machine { get; set; }

        /// <summary>
        /// 사업장 전기 권한
        /// </summary>
        public bool PlacePerm_Elec { get; set; }

        /// <summary>
        /// 사업장 승강 권한
        /// </summary>
        public bool PlacePerm_Lift { get; set; }

        /// <summary>
        /// 사업장 소방 권한
        /// </summary>
        public bool PlacePerm_Fire { get; set; }

        /// <summary>
        /// 사업장 건축 권한
        /// </summary>
        public bool PlacePerm_Construct { get; set; }

        /// <summary>
        /// 사업장 통신 권한
        /// </summary>
        public bool PlacePerm_Network { get; set; }

        /// <summary>
        /// 사업장 미화 권한
        /// </summary>
        public bool PlacePerm_Beauty { get; set; }

        /// <summary>
        /// 사업장 보안 권한
        /// </summary>
        public bool PlacePerm_Security { get; set; }

        /// <summary>
        /// 사업장 자재 권한
        /// </summary>
        public bool PlacePerm_Material { get; set; }

        /// <summary>
        /// 사업장 에너지 권한
        /// </summary>
        public bool PlacePerm_Energy { get; set; }

        /// <summary>
        /// 사업장 VOC 권한
        /// </summary>
        public bool PlacePerm_Voc { get; set; }
        #endregion
    }
}
