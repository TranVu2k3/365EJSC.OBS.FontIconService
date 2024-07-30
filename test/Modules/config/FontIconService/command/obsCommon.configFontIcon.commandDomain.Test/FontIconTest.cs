namespace obsCommon.configFontIcon.commandDomain.Test
{
    public class FontIconTest
    {
        [Fact]
        public void Should_Create_FontIcon_With_Valid_Properties()
        {
            var description = "Valid Description";
            var type = "Valid Type";
            var version = "Valid Version";
            bool isActived = true;

            var fontIcon = new Entities.FontIcon
            {
                Description = description,
                Type = type,
                Version = version,
                IsActived = isActived
            };

            Assert.Equal(description, fontIcon.Description);
            Assert.Equal(type, fontIcon.Type);
            Assert.Equal(version, fontIcon.V);
            Assert.Equal(isActived, fontIcon.IsActived);
        }
    }
}
