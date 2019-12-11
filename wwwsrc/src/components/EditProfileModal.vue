<template>
  <div id="edit-profile-modal" class="modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Edit Your Profile</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="editProfile()">
            <div class="form-group">
              <label for="dob">Date of Birth</label>
              <input
                type="date"
                class="form-control"
                id="dob"
                placeholder="MM/DD/YYYY"
                v-model="editUser.dob"
                required
              />
            </div>
            <div class="form-group">
              <label for="gender">Gender</label>
              <input
                type="text"
                class="form-control"
                id="gender"
                placeholder="M or F"
                v-model="editUser.gender"
                required
              />
              <div class="form-group">
                <label for="height">Height</label>
                <input
                  type="number"
                  class="form-control"
                  id="height"
                  placeholder="Enter height in inches"
                  v-model="editUser.height"
                />
              </div>
              <div class="form-group">
                <label for="startdate">Start Date</label>
                <input
                  type="date"
                  class="form-control"
                  id="startdate"
                  placeholder="Start Date MM/DD/YYYY"
                  v-model="editUser.startdate"
                />
              </div>
              <div class="form-group">
                <label for="startweight">Starting Weight</label>
                <input
                  type="number"
                  class="form-control"
                  id="startweight"
                  placeholder="Starting weight in pounds"
                  v-model="editUser.startweight"
                />
              </div>
              <div class="form-group">
                <label for="goalweight">Goal Weight</label>
                <input
                  type="number"
                  class="form-control"
                  id="goalweight"
                  placeholder="Goal weight in pounds"
                  v-model="editUser.goalweight"
                />
              </div>
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "edit-profile-modal",
  data() {
    return {
      editUser: {}
    };
  },
  computed: {},
  methods: {
    editProfile() {
      this.$store.dispatch("editpProfile", this.editUser);
      this.editUser = {};
      $(".close").click();
    }
  },
  components: {}
};
</script>

<style scoped>
</style>