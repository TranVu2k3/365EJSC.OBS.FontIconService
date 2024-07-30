namespace obsCommon.configFontIcon.commandPresentation.DTOs
{
    public class UpdateFontIconRequestDTO
    {
        public string Description { get; set; }

        public string Type { get; set; }

        public string? Version { get; set; }

        public bool IsActived { get; set; }
    }
}
