<script setup lang="ts">
import landingImage from '../assets/landing.png';
import landingImageBad from '../assets/landingCompressed.jpg';
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { mdiHeart, mdiDuck } from '@mdi/js';

const { currentRoute, push } = useRouter();

const searchText = ref(currentRoute.value?.query['q'] ?? '');

function fakeSearchFocused() {
	push({
		path: '/search',
		query: currentRoute.value.query,
	});
}
</script>

<template>
	<div style="position: relative; z-index: 1; min-height: 100vh">
		<v-img :lazy-src="landingImageBad" :src="landingImage" cover height="100vh" class="tinted">
			<v-container class="d-flex flex-column text-center w-100 h-100 overlay text-white header">
				<span class="text-h3 text-md-h2 text-lg-h1 pt-16">Матроссинг</span>
				<span class="text-h7 text-md-h6 text-lg-h5 pt-5">Студенческая программа для обмена материалами</span>
				<div class="flex pt-8">
					<v-text-field
						v-model="searchText"
						label="Найди что-нибудь!"
						variant="solo"
						density="compact"
						@update:focused="fakeSearchFocused"
					/>
				</div>
			</v-container>
		</v-img>
	</div>

	<v-footer style="position: sticky; bottom: 0" class="justify-center" color="rgb(0,1,76)">
		Made with
		<v-icon :icon="mdiHeart" color="red" start end />
		by
		<v-icon :icon="mdiDuck" color="yellow" end />
	</v-footer>
</template>

<style scoped>
.header {
	font-family: 'IBM Plex Sans', Roboto, sans-serif;
}

.overlay {
	z-index: 1;
	position: relative;
}

.tinted::before {
	content: '';
	display: block;
	position: absolute;
	inset: 0;
	background-color: rgba(0 0 0 / 66%);
}
</style>
