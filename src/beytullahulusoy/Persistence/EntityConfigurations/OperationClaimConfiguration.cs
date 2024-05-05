using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Announcements.Constants;
using Application.Features.Attendances.Constants;
using Application.Features.Groups.Constants;
using Application.Features.Recourses.Constants;
using Application.Features.Sponsors.Constants;
using Application.Features.Trainings.Constants;
using Application.Features.TrainingRooms.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Announcements
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Read },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Write },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Create },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Update },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Attendances
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AttendancesOperationClaims.Admin },
                new() { Id = ++lastId, Name = AttendancesOperationClaims.Read },
                new() { Id = ++lastId, Name = AttendancesOperationClaims.Write },
                new() { Id = ++lastId, Name = AttendancesOperationClaims.Create },
                new() { Id = ++lastId, Name = AttendancesOperationClaims.Update },
                new() { Id = ++lastId, Name = AttendancesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Groups
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = GroupsOperationClaims.Admin },
                new() { Id = ++lastId, Name = GroupsOperationClaims.Read },
                new() { Id = ++lastId, Name = GroupsOperationClaims.Write },
                new() { Id = ++lastId, Name = GroupsOperationClaims.Create },
                new() { Id = ++lastId, Name = GroupsOperationClaims.Update },
                new() { Id = ++lastId, Name = GroupsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Recourses
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = RecoursesOperationClaims.Admin },
                new() { Id = ++lastId, Name = RecoursesOperationClaims.Read },
                new() { Id = ++lastId, Name = RecoursesOperationClaims.Write },
                new() { Id = ++lastId, Name = RecoursesOperationClaims.Create },
                new() { Id = ++lastId, Name = RecoursesOperationClaims.Update },
                new() { Id = ++lastId, Name = RecoursesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Sponsors
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SponsorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SponsorsOperationClaims.Read },
                new() { Id = ++lastId, Name = SponsorsOperationClaims.Write },
                new() { Id = ++lastId, Name = SponsorsOperationClaims.Create },
                new() { Id = ++lastId, Name = SponsorsOperationClaims.Update },
                new() { Id = ++lastId, Name = SponsorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Trainings
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TrainingsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TrainingsOperationClaims.Read },
                new() { Id = ++lastId, Name = TrainingsOperationClaims.Write },
                new() { Id = ++lastId, Name = TrainingsOperationClaims.Create },
                new() { Id = ++lastId, Name = TrainingsOperationClaims.Update },
                new() { Id = ++lastId, Name = TrainingsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region TrainingRooms
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TrainingRoomsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TrainingRoomsOperationClaims.Read },
                new() { Id = ++lastId, Name = TrainingRoomsOperationClaims.Write },
                new() { Id = ++lastId, Name = TrainingRoomsOperationClaims.Create },
                new() { Id = ++lastId, Name = TrainingRoomsOperationClaims.Update },
                new() { Id = ++lastId, Name = TrainingRoomsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
