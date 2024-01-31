namespace Dummy_API.DTO
{
    public class DummyDetailResponse
    {
        public int DetailId { get; set; }
        public string DetailName { get; set; } = null!;
        public int MasterId { get; set; }

        public virtual DummyMasterResponse Master { get; set; } = null!;
    }
}
