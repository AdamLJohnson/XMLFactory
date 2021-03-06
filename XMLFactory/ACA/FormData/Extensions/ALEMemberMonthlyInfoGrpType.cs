using XMLFactory.Common;

namespace XMLFactory.ACA.FormData
{
    /// <summary>
    /// Implements the serialization virtual functions for the generated code.  This was implemented to accomodate
    /// omitting serialazation dependent on nested classes being populated.  Had the IRS done something more sane
    /// this wouldn't be here.  However the specification forces removal of parent elements if child elements are 
    /// null, there can be multiple levels of nesting, and the built in .NET mechanisms to do this fail in that case.
    /// The rules are also not intuitive, with some blank elements required and some not.
    /// 
    /// If one of these is incorrect the entire file will be rejected.  If this happens in production buy me 
    /// a big bottle of whiskey please.  Taking a vacation.
    /// </summary>
    public partial class ALEMemberMonthlyInfoGrpType
    {
        public bool ShouldSerializeMinEssentialCvrOffrCd() {
            return (_minEssentialCvrOffrCd != DigitCodeType.False);
        }
        public bool ShouldSerializeAggregatedGroupInd() {
            return (_aggregatedGroupInd != DigitBooleanType.False);
        }
        public bool ShouldSerializealeMemberFTECnt() {
            return (!Helper.IsZeroOrWhitespace(_aLEMemberFTECnt));
        }
        public bool ShouldSerializeTotalEmployeeCnt() {
            return (!string.IsNullOrWhiteSpace(_totalEmployeeCnt));
        }
        public bool ShouldSerializeALESect4980HTrnstReliefCd() {
            return (!string.IsNullOrWhiteSpace(_aLESect4980HTrnstReliefCd));
        }
        /// <summary>
        /// If any one month has a value, write out the entire group.  The ShouldSerialize 
        /// virutual method of the serializer class only applies to properties.  This method
        /// can be called from the property instance created in the calling object.
        /// </summary>
        public bool ShouldSerialize() {
            return
                ShouldSerializeAggregatedGroupInd() ||
                ShouldSerializeALESect4980HTrnstReliefCd() ||
                ShouldSerializeMinEssentialCvrOffrCd() ||
                ShouldSerializeTotalEmployeeCnt() ||
                ShouldSerializealeMemberFTECnt();
        }
    }
}
