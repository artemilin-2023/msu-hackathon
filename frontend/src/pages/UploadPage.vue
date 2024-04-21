<template>
	<v-sheet width="100vw" height="100vh" class="px-5 d-flex text-align-center flex-column justify-center align-center">
		<span class="text-h3" style="text-align: center">Загрузка файлов</span>

		<v-form style="min-width: 300px" class="pt-4">
			<v-container>
				<v-row><v-autocomplete label="Курс" :items="[1, 2, 3, 4, 5, 6, 7, 8]" multiple></v-autocomplete></v-row
				><v-row
					><v-autocomplete
						label="Предмет"
						:items="[
							'Математический анализ',
							'Линейная алгебра',
							'Общая физика',
							'Georgia',
							'Texas',
							'Wyoming',
						]"
						multiple
					></v-autocomplete></v-row
				><v-row
					><v-autocomplete
						label="Тип материала"
						:items="['California', 'Colorado', 'Florida', 'Georgia', 'Texas', 'Wyoming']"
						multiple
					></v-autocomplete></v-row
				><v-row><v-file-input clearable label="Материал" multiple></v-file-input></v-row
				><v-row><v-btn class="mt-2" type="submit" block>Submit</v-btn></v-row>
			</v-container>
		</v-form>
		<!-- <v-sheet elevation2 style="z-index: 2"
			><v-text-field
				v-model="searchText"
				autofocus
				hide-details="auto"
				style="padding: 2vh 3vw"
				variant="solo"
				density="comfortable"
				label="Найдите что-нибудь"
				placeholder="Физика"
				clearable
				@update:model-value="doSearch"
				@keydown.enter.prevent="unfocusAndSearch"
			>
				<template #prepend>
					<v-icon
						:icon="mdiHome"
						class="mx-0"
						@click="push({ path: '/', query: currentRoute.query })"
					/> </template
				><template #append>
					<v-icon :icon="mdiMagnify" class="mx-0" @click="unfocusAndSearch" /> </template></v-text-field
		></v-sheet>
		<v-sheet> </v-sheet> -->
	</v-sheet>
</template>
