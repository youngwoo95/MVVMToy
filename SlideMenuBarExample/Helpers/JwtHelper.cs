using SlideMenuBarExample.Commands.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace SlideMenuBarExample.Helpers
{
    public class JwtHelper
    {
        public static bool DecodeJWTToken(string token, IAuthService authService)
        {
            var handler = new JwtSecurityTokenHandler();

            // 토큰을 읽어 JwtSecurityToken 객체로 변환
            var jwtToken = handler.ReadJwtToken(token);

#region 사용자 정보관련
            // 사업장 ID
            string? PlaceIdClaim = jwtToken.GetClaimValue("PlaceIdx");
            if(!String.IsNullOrWhiteSpace(PlaceIdClaim) && int.TryParse(PlaceIdClaim, out int PlaceId))
            {
                authService.PlaceId = PlaceId;
            }
            else return false;

            // 사업장 명
            string? PlaceNameClaim= jwtToken.GetClaimValue("PlaceName");
            if (!String.IsNullOrWhiteSpace(PlaceNameClaim))
            {
                authService.PlaceName = PlaceNameClaim;
            }
            else return false;

            // 사업장 생성일
            string? PlaceCreateDTClaim = jwtToken.GetClaimValue("PlaceCreateDT");
            if (!String.IsNullOrWhiteSpace(PlaceCreateDTClaim))
            {
                authService.PlaceCreateDT = PlaceCreateDTClaim;
            }
            else return false;

            // 사용자 ID
            string? UserIdxClaim = jwtToken.GetClaimValue("UserIdx");
            if (!String.IsNullOrWhiteSpace(UserIdxClaim) && int.TryParse(UserIdxClaim, out int UserId))
            {
                authService.UserId = UserId;
            }
            else return false;

            // 사용자 이름
            string? UserNameClaim = jwtToken.GetClaimValue("Name");
            if (!String.IsNullOrWhiteSpace(UserNameClaim))
            {
                authService.UserName = UserNameClaim;
            }
            else return false;

            // 사용자 타입
            string? UserTypeClaim = jwtToken.GetClaimValue("UserType");
            if (!String.IsNullOrWhiteSpace(UserTypeClaim))
            {
                authService.UserType = UserTypeClaim;
            }
            else return false;

            // 알람 여부
            string? AlarmClaim = jwtToken.GetClaimValue("AlarmYN");
            if (!String.IsNullOrWhiteSpace(AlarmClaim) && bool.TryParse(AlarmClaim, out bool AlarmYN))
            {
                authService.AlarmYN = AlarmYN;
            }
            else return false;
            
            // 관리자 여부
            string? AdminClaim = jwtToken.GetClaimValue("AdminYN");
            if (!String.IsNullOrWhiteSpace(AdminClaim) && bool.TryParse(AdminClaim, out bool AdminYN))
            {
                authService.AdminYN = AdminYN;
            }
            else return false;

            string? RoleClaim = jwtToken.GetClaimValue("Role");
            if (!String.IsNullOrWhiteSpace(RoleClaim))
            {
                authService.Role = RoleClaim;
            }
            else return false;
#endregion

#region 사용자 권한관련
            // 기본정보 권한
            string? UserPermBasicClaim = jwtToken.GetClaimValue("UserPerm_Basic");
            if (!String.IsNullOrWhiteSpace(UserPermBasicClaim) && int.TryParse(UserPermBasicClaim, out int UserPermBasic))
            {
                authService.UserPerm_Basic = UserPermBasic;
            }
            else return false;

            // 기계관리 권한
            string? UserPermMachineClaim = jwtToken.GetClaimValue("UserPerm_Machine");
            if (!String.IsNullOrWhiteSpace(UserPermMachineClaim) && int.TryParse(UserPermMachineClaim, out int UserPermMachine))
            {
                authService.UserPerm_Machine = UserPermMachine;
            }
            else return false;

            // 전기관리 권한
            string? UserPermElecClaim = jwtToken.GetClaimValue("UserPerm_Elec");
            if (!String.IsNullOrWhiteSpace(UserPermElecClaim) && int.TryParse(UserPermElecClaim, out int UserPermElec))
            {
                authService.UserPerm_Elec = UserPermElec;
            }
            else return false;

            // 승강관리 권한
            string? UserPermLiftClaim = jwtToken.GetClaimValue("UserPerm_Lift");
            if (!String.IsNullOrWhiteSpace(UserPermLiftClaim) && int.TryParse(UserPermLiftClaim, out int UserPermLift))
            {
                authService.UserPerm_Lift = UserPermLift;
            }
            else return false;

            // 소방관리 권한
            string? UserPermFireClaim = jwtToken.GetClaimValue("UserPerm_Fire");
            if (!String.IsNullOrWhiteSpace(UserPermFireClaim) && int.TryParse(UserPermFireClaim, out int UserPermFire))
            {
                authService.UserPerm_Fire = UserPermFire;
            }
            else return false;

            // 건축관리 권한
            string? UserPermConstructClaim = jwtToken.GetClaimValue("UserPerm_Construct");
            if (!String.IsNullOrWhiteSpace(UserPermConstructClaim) && int.TryParse(UserPermConstructClaim, out int UserPermConstruct))
            {
                authService.UserPerm_Construct = UserPermConstruct;
            }
            else return false;

            // 통신관리 권한
            string? UserPermNetworkClaim = jwtToken.GetClaimValue("UserPerm_Network");
            if (!String.IsNullOrWhiteSpace(UserPermNetworkClaim) && int.TryParse(UserPermNetworkClaim, out int UserPermNetwork))
            {
                authService.UserPerm_Network = UserPermNetwork;
            }
            else return false;

            // 미화관리 권한
            string? UserPermBeautyClaim = jwtToken.GetClaimValue("UserPerm_Beauty");
            if (!String.IsNullOrWhiteSpace(UserPermBeautyClaim) && int.TryParse(UserPermBeautyClaim, out int UserPermBeauty))
            {
                authService.UserPerm_Beauty = UserPermBeauty;
            }
            else return false;

            // 보안관리 권한
            string? UserPermSecurityClaim = jwtToken.GetClaimValue("UserPerm_Security");
            if (!String.IsNullOrWhiteSpace(UserPermSecurityClaim) && int.TryParse(UserPermSecurityClaim, out int UserPermSecurity))
            {
                authService.UserPerm_Security = UserPermSecurity;
            }
            else return false;

            // 자재관리 권한
            string? UserPermMaterialClaim = jwtToken.GetClaimValue("UserPerm_Material");
            if (!String.IsNullOrWhiteSpace(UserPermMaterialClaim) && int.TryParse(UserPermMaterialClaim, out int UserPermMaterial))
            {
                authService.UserPerm_Material = UserPermMaterial;
            }
            else return false;

            // 에너지관리 권한
            string? UserPermEnergyClaim = jwtToken.GetClaimValue("UserPerm_Energy");
            if (!String.IsNullOrWhiteSpace(UserPermEnergyClaim) && int.TryParse(UserPermEnergyClaim, out int UserPermEnergy))
            {
                authService.UserPerm_Energy = UserPermEnergy;
            }
            else return false;

            // 사용자관리 권한
            string? UserPermUserClaim = jwtToken.GetClaimValue("UserPerm_User");
            if (!String.IsNullOrWhiteSpace(UserPermUserClaim) && int.TryParse(UserPermUserClaim, out int UserPermUser))
            {
                authService.UserPerm_User = UserPermUser;
            }
            else return false;

            // 민원관리 권한
            string? UserPermVocClaim = jwtToken.GetClaimValue("UserPerm_Voc");
            if (!String.IsNullOrWhiteSpace(UserPermVocClaim) && int.TryParse(UserPermVocClaim, out int UserPermVoc))
            {
                authService.UserPerm_Voc = UserPermVoc;
            }
            else return false;
#endregion

#region VOC 권한 관련
            // 기계민원
            string? VocMachineClaim = jwtToken.GetClaimValue("VocMachine");
            if (!String.IsNullOrWhiteSpace(VocMachineClaim) && bool.TryParse(VocMachineClaim, out bool VocMachine))
            {
                authService.VocMachine = VocMachine;
            }
            else return false;

            // 전기민원
            string? VocElecClaim = jwtToken.GetClaimValue("VocElec");
            if (!String.IsNullOrWhiteSpace(VocElecClaim) && bool.TryParse(VocElecClaim, out bool VocElec))
            {
                authService.VocElec = VocElec;
            }
            else return false;

            // 승강민원
            string? VocLiftClaim = jwtToken.GetClaimValue("VocLift");
            if (!String.IsNullOrWhiteSpace(VocLiftClaim) && bool.TryParse(VocLiftClaim, out bool VocLift))
            {
                authService.VocLift = VocLift;
            }
            else return false;

            // 소방민원
            string? VocFireClaim = jwtToken.GetClaimValue("VocFire");
            if (!String.IsNullOrWhiteSpace(VocFireClaim) && bool.TryParse(VocFireClaim, out bool VocFire))
            {
                authService.VocFire = VocFire;
            }
            else return false;

            // 건축민원
            string? VocConstructClaim = jwtToken.GetClaimValue("VocConstruct");
            if (!String.IsNullOrWhiteSpace(VocConstructClaim) && bool.TryParse(VocConstructClaim, out bool VocConstruct))
            {
                authService.VocConstruct = VocConstruct;
            }
            else return false;

            // 통신민원
            string? VocNetworkClaim = jwtToken.GetClaimValue("VocNetwork");
            if (!String.IsNullOrWhiteSpace(VocNetworkClaim) && bool.TryParse(VocNetworkClaim, out bool VocNetwork))
            {
                authService.VocNetWork = VocNetwork;
            }
            else return false;

            // 미화민원
            string? VocBeautyClaim = jwtToken.GetClaimValue("VocBeauty");
            if (!String.IsNullOrWhiteSpace(VocBeautyClaim) && bool.TryParse(VocBeautyClaim, out bool VocBeauty))
            {
                authService.VocBeauty = VocBeauty;
            }
            else return false;

            // 보안민원
            string? VocSecurityClaim = jwtToken.GetClaimValue("VocSecurity");
            if (!String.IsNullOrWhiteSpace(VocSecurityClaim) && bool.TryParse(VocSecurityClaim, out bool VocSecurity))
            {
                authService.VocSecurity = VocSecurity;
            }
            else return false;

            // 미분류 민원
            string? VocDefaultClaim = jwtToken.GetClaimValue("VocDefault");
            if(!String.IsNullOrWhiteSpace(VocDefaultClaim) && bool.TryParse(VocDefaultClaim, out bool VocDefault))
            {
                authService.VocDefault = VocDefault;
            }
            else return false;
            #endregion

#region 사업장 권한
            // 사업장 기계권한
            string? PlacePermMachineClaim = jwtToken.GetClaimValue("PlacePerm_Machine");
            if (!String.IsNullOrWhiteSpace(PlacePermMachineClaim) && bool.TryParse(PlacePermMachineClaim, out bool PlacePermMachine))
            {
                authService.PlacePerm_Machine = PlacePermMachine;
            }
            else return false;

            // 사업장 전기권한
            string? PlacePermElecClaim = jwtToken.GetClaimValue("PlacePerm_Elec");
            if (!String.IsNullOrWhiteSpace(PlacePermElecClaim) && bool.TryParse(PlacePermElecClaim, out bool PlacePermElec))
            {
                authService.PlacePerm_Elec = PlacePermElec;
            }
            else return false;

            // 사업장 승강권한
            string? PlacePermLiftClaim = jwtToken.GetClaimValue("PlacePerm_Lift");
            if (!String.IsNullOrWhiteSpace(PlacePermLiftClaim) && bool.TryParse(PlacePermLiftClaim, out bool PlacePermLift))
            {
                authService.PlacePerm_Lift = PlacePermLift;
            }
            else return false;

            // 사업장 소방권한
            string? PlacePermFireClaim = jwtToken.GetClaimValue("PlacePerm_Fire");
            if (!String.IsNullOrWhiteSpace(PlacePermFireClaim) && bool.TryParse(PlacePermFireClaim, out bool PlacePermFire))
            {
                authService.PlacePerm_Fire = PlacePermFire;
            }
            else return false;

            // 사업장 건축권한
            string? PlacePermConstructClaim = jwtToken.GetClaimValue("PlacePerm_Construct");
            if (!String.IsNullOrWhiteSpace(PlacePermConstructClaim) && bool.TryParse(PlacePermConstructClaim, out bool PlacePermConstruct))
            {
                authService.PlacePerm_Construct = PlacePermConstruct;
            }
            else return false;

            // 사업장 통신권한
            string? PlacePermNetWorkClaim = jwtToken.GetClaimValue("PlacePerm_Network");
            if (!String.IsNullOrWhiteSpace(PlacePermNetWorkClaim) && bool.TryParse(PlacePermNetWorkClaim, out bool PlacePermNetwork))
            {
                authService.PlacePerm_Network = PlacePermNetwork;
            }
            else return false;

            // 사업장 미화권한
            string? PlacePermBeautyClaim = jwtToken.GetClaimValue("PlacePerm_Beauty");
            if (!String.IsNullOrWhiteSpace(PlacePermBeautyClaim) && bool.TryParse(PlacePermBeautyClaim, out bool PlacePermBeauty))
            {
                authService.PlacePerm_Beauty = PlacePermBeauty;
            }
            else return false;

            // 사업장 보안권한
            string? PlacePermSecurityClaim = jwtToken.GetClaimValue("PlacePerm_Security");
            if (!String.IsNullOrWhiteSpace(PlacePermSecurityClaim) && bool.TryParse(PlacePermSecurityClaim, out bool PlacePermSecurity))
            {
                authService.PlacePerm_Security = PlacePermSecurity;
            }
            else return false;

            // 사업장 자재권한
            string? PlacePermMaterialClaim = jwtToken.GetClaimValue("PlacePerm_Material");
            if (!String.IsNullOrWhiteSpace(PlacePermMaterialClaim) && bool.TryParse(PlacePermMaterialClaim, out bool PlacePermMaterial))
            {
                authService.PlacePerm_Material = PlacePermMaterial;
            }
            else return false;

            // 사업장 에너지권한
            string? PlacePermEnergyClaim = jwtToken.GetClaimValue("PlacePerm_Energy");
            if (!String.IsNullOrWhiteSpace(PlacePermEnergyClaim) && bool.TryParse(PlacePermEnergyClaim, out bool PlacePermEnergy))
            {
                authService.PlacePerm_Energy = PlacePermEnergy;
            }
            else return false;

            // 사업장 VOC권한
            string? PlacePermVocClaim = jwtToken.GetClaimValue("PlacePerm_Voc");
            if (!String.IsNullOrWhiteSpace(PlacePermVocClaim) && bool.TryParse(PlacePermVocClaim, out bool PlacePermVoc))
            {
                authService.PlacePerm_Voc = PlacePermVoc;
            }
            else return false;

            authService.Token = token;

#endregion


            Console.WriteLine("asdasd");
            return true;
        }

        

    }

    public static class JwtExtensions
    {
        public static string GetClaimValue(this JwtSecurityToken token, string ClaimType)
        {
            return token.Claims.FirstOrDefault(m => m.Type == ClaimType)?.Value ?? String.Empty;
        }
    }
}
