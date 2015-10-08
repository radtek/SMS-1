<?php $thisPage="submit details"; ?>
<?php include 'header-products.php'; ?>

<!-- Primary Page Layout
–––––––––––––––––––––––––––––––––––––––––––––––––– -->
<div class="container submit subPage">
	<div class="row">
		<div class="twelve columns">
			<h1>Please ensure that the details you enter below are accurate. Inaccurate details cannot be verified and will result in unsuccessful registration.</h1>
			<div class="contact_form">
				<form action="mailer.php" method="post" class="contactform" />
					<input type="hidden" name="recipient" value="enquiries@safemovescheme.co.uk">
					<div class="row">
						<div class="twelve columns left">
							<input type="text" onfocus="if(this.value=='')this.value='';" onblur="if(this.value=='')this.value='';" name="Company&nbsp;Name" 												class="input-textarea"
							placeholder="Company Name" id="fname" />
						</div>
					</div>
					<div class="row">
						<div class="twelve columns" id="locationField">
							<input id="autocomplete" placeholder="Enter your address" onFocus="geolocate()" type="text"></input>
						</div>
						<table class="six columns" id="address">
							<tr>
								<td class="label">Street address</td>
								<td class="slimField"><input class="field" name="Street&nbsp;Number" id="street_number" disabled="true"></input></td>
								<td class="wideField" colspan="2"><input name="Street&nbsp;Name" class="field" id="route" disabled="true"></input></td>
							</tr>
							<tr>
								<td class="label">Town / City</td>
								<td class="wideField" colspan="3"><input name="Town&nbsp;/&nbsp;City" class="field" id="locality" disabled="true"></input></td>
							</tr>
							<tr class="none">
    							<td class="label">Postcode</td>
								<td class="wideField" colspan="3"><input class="field" name="Postcode" id="postal_code" disabled="true"></input></td>
							</tr>
							<tr>
								<td class="label">State</td>
								<td class="slimField"><input class="field" name="State" id="administrative_area_level_1" disabled="true"></input></td>
								<td class="label hideAll">Postcode</td>
								<td class="wideField hideAll"><input class="field" name="Postcode" id="postal_code" disabled="true"></input></td>
							</tr>

							<tr>
								<td class="label">Country</td>
								<td class="wideField" colspan="3"><input name="Country" class="field" id="country" disabled="true"></input></td>
							</tr>
						</table>
					</div>
					<div class="row">
						<div class="six columns">
							<select class="regulator" name="Regulator">
								<option value="Regulator 1">Regulator</option>
								<option value="Regulator 2">Regulator 1</option>
								<option value="Regulator 3">Regulator 2</option>
								<option value="Regulator 4">Regulator 3</option>
							</select>
						</div>
						<div class="six columns">
							<div class="six columns no-margin left width">
								<input type="text" onfocus="if(this.value=='')this.value='';" onblur="if(this.value=='')this.value='';" 																	name="Regulator&nbsp;ID&nbsp;Number&nbsp;/&nbsp;MIS" class="input-textarea"
								placeholder="Regulator ID Number / MIS" id="fname" />
							</div>
						</div>
						<p>System Administrator Details – Please read the note below to ensure the correct person is registered as the System Administrator</p>
						<p>Important note: The System Administrator will manage the firm's Safe Move Scheme registration and user administration on an ongoing basis; there can only be 1 System Administrator per firm; the System Administrator MUST be either registered with the CLC with a personal MIS number AND be displayed on the CLC website as having a 'Manager' licence type or registered with the SRA as an 'Approved Manager'; the System Administrator must be contactable via the telephone number provided below which must also be listed on the regulator's website.</p>
					</div>
					<div class="row">
						<div class="six columns">
							<select class="title" name="Title">
								<option value="(Title)">(Title)</option>
								<option value="Mr">Mr</option>
								<option value="Mrs">Mrs</option>
								<option value="Miss">Miss</option>
								<option value="Ms">MS</option>
								<option value="Master">Master</option>
								<option value="Dr">Dr</option>
							</select>
						</div>
					</div>
					<div class="row">
						<div class="six columns no-margin left">
						<input type="text" onfocus="if(this.value=='')this.value='';" onblur="if(this.value=='')this.value='';" name="First&nbsp;Name" class="input-textarea" 								id="bTelephone" placeholder="First Name*" required/>
						</div>
						<div class="six columns right">
							<input type="text" onfocus="if(this.value=='')this.value='';" onblur="if(this.value=='')this.value='';" name="Last&nbsp;Name" 												class="input-textarea" id="bemail" placeholder="Last Name*" required/>
						</div>
					</div>
					<div class="row">
						<div class="six columns right">
							<input type="email" onfocus="if(this.value=='')this.value='';" onblur="if(this.value=='')this.value='';" name="Email" class="input-textarea" 								id="bemail" placeholder="Email*" required/>
						</div>
						<div class="six columns right">
							<input type="tel" onfocus="if(this.value=='')this.value='';" onblur="if(this.value=='')this.value='';" name="Telephone" class="input-textarea" 								id="bemail" placeholder="Telephone"/>
						</div>
						<div class="twelve columns">
							<input class="input-submit" type="submit" value="Submit" name="submit">
						</div>
					</div>
					<script>
						// This example displays an address form, using the autocomplete feature
						// of the Google Places API to help users fill in the information.

						var placeSearch, autocomplete;
						var componentForm = {
						  street_number: 'short_name',
						  route: 'long_name',
						  locality: 'long_name',
						  administrative_area_level_1: 'short_name',
						  country: 'long_name',
						  postal_code: 'short_name'
						};

						function initAutocomplete() {
						  // Create the autocomplete object, restricting the search to geographical
						  // location types.
						  autocomplete = new google.maps.places.Autocomplete(
						      /** @type {!HTMLInputElement} */(document.getElementById('autocomplete')),
						      {types: ['geocode']});

						  // When the user selects an address from the dropdown, populate the address
						  // fields in the form.
						  autocomplete.addListener('place_changed', fillInAddress);
						}

						// [START region_fillform]
						function fillInAddress() {
						  // Get the place details from the autocomplete object.
						  var place = autocomplete.getPlace();

						  for (var component in componentForm) {
						    document.getElementById(component).value = '';
						    document.getElementById(component).disabled = false;
						  }

						  // Get each component of the address from the place details
						  // and fill the corresponding field on the form.
						  for (var i = 0; i < place.address_components.length; i++) {
						    var addressType = place.address_components[i].types[0];
						    if (componentForm[addressType]) {
						      var val = place.address_components[i][componentForm[addressType]];
						      document.getElementById(addressType).value = val;
						    }
						  }
						}
						// [END region_fillform]

						// [START region_geolocation]
						// Bias the autocomplete object to the user's geographical location,
						// as supplied by the browser's 'navigator.geolocation' object.
						function geolocate() {
						  if (navigator.geolocation) {
						    navigator.geolocation.getCurrentPosition(function(position) {
						      var geolocation = {
						        lat: position.coords.latitude,
						        lng: position.coords.longitude
						      };
						      var circle = new google.maps.Circle({
						        center: geolocation,
						        radius: position.coords.accuracy
						      });
						      autocomplete.setBounds(circle.getBounds());
						    });
						  }
						}
						// [END region_geolocation]

					    </script>
					    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAXE_5b9YIrF7IrXQA6DRbWry38BroGaCI&signed_in=true&libraries=places&callback=initAutocomplete"
					        async defer></script>
				</form>
			</div>
		</div>
	</div>
</div>
<?php include 'sponsors.php'; ?>

<!-- End Document
–––––––––––––––––––––––––––––––––––––––––––––––––– -->

<?php include 'footer.php'; ?>